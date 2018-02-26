﻿using UnityEngine;
using System;
using System.Collections;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Animator))]

public class IKController : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private Transform[] IKGoalTransforms;
    [SerializeField]
    private AvatarIKGoal[] AvatarIKGoals;
    [SerializeField]
    private GameObject[] lookObj;
    [SerializeField]
    private GameObject Head;
    [SerializeField]
    private Hand rightHand;
    [SerializeField]
    private Hand leftHand;
    private Hand[] Hands;
    public Vector3[] roThumb, roIndex, roMiddle, roRing, roLittle;
    public Vector3[] rcThumb, rcIndex, rcMiddle, rcRing, rcLittle;
    public Vector3[] loThumb, loIndex, loMiddle, loRing, loLittle;
    public Vector3[] lcThumb, lcIndex, lcMiddle, lcRing, lcLittle;
    private Vector3[][] rightOpenRotate;
    private Vector3[][] rightCloseRotate;
    private Vector3[][] leftOpenRotate;
    private Vector3[][] leftCloseRotate;
    private Vector3[][][] hr;
    [SerializeField]
    private HumanBodyBones[] rightHandBone;
    [SerializeField]
    private HumanBodyBones[] leftHandBone;
    private HumanBodyBones[][] HandBone;
    [SerializeField]
    private float BoneMoveSpeed;
    [SerializeField]
    private float AnimationWeight;
    [SerializeField]
    private GameObject Tracker;
    private bool[] handShakeBool;
    private void Init()
    {
        animator = GetComponent<Animator>();
        rightOpenRotate = new Vector3[5][];
        rightCloseRotate = new Vector3[5][];
        leftOpenRotate = new Vector3[5][];
        leftCloseRotate = new Vector3[5][];
        Hands = new Hand[2] { rightHand, leftHand };
        HandBone = new HumanBodyBones[2][] { rightHandBone, leftHandBone };
        hr = new Vector3[4][][] { rightOpenRotate, rightCloseRotate, leftOpenRotate, leftCloseRotate };
        handShakeBool = new bool[5];
        MakeOpenHandShakeArray();
        MakeRotateArray();
        
    }
    private void MakeRotateArray()
    {
        rightOpenRotate[0] = roThumb;
        rightOpenRotate[1] = roIndex;
        rightOpenRotate[2] = roMiddle;
        rightOpenRotate[3] = roRing;
        rightOpenRotate[4] = roLittle;
        rightCloseRotate[0] = rcThumb;
        rightCloseRotate[1] = rcIndex;
        rightCloseRotate[2] = rcMiddle;
        rightCloseRotate[3] = rcRing;
        rightCloseRotate[4] = rcLittle;
        leftOpenRotate[0] = loThumb;
        leftOpenRotate[1] = loIndex;
        leftOpenRotate[2] = loMiddle;
        leftOpenRotate[3] = loRing;
        leftOpenRotate[4] = loLittle;
        leftCloseRotate[0] = lcThumb;
        leftCloseRotate[1] = lcIndex;
        leftCloseRotate[2] = lcMiddle;
        leftCloseRotate[3] = lcRing;
        leftCloseRotate[4] = lcLittle;
    }
    private void MakeOpenHandShakeArray()
    {
        for (int i = 0; i < 5; i++)
        {
            handShakeBool[i] = true;
        }

    }
    private void Start()
    {
        Init();
    }
    void OnAnimatorIK()
    {
        debug("OnAnimator");
        animator.SetLookAtWeight(AnimationWeight);
        animator.SetLookAtPosition(lookObj[(lookObj[0] != null) ? 0 : 1].transform.position);
        for (int i = 0; i < 4; i++)
        {
            if (IKGoalTransforms[i] != null)
            {
                Vector3 pos = IKGoalTransforms[i].position;
                Quaternion rot = IKGoalTransforms[i].rotation;
                animator.SetIKPositionWeight(AvatarIKGoals[i], AnimationWeight);
                animator.SetIKPosition(AvatarIKGoals[i], pos);
                animator.SetIKRotationWeight(AvatarIKGoals[i], AnimationWeight);
                animator.SetIKRotation(AvatarIKGoals[i], rot);
            }
        }
        for (int t = 0; t <= 1; t++)
        {
            if (Hands[t].controller != null)
            {
                var Device = Hands[t].controller;
                if (Device.GetPress(SteamVR_Controller.ButtonMask.Grip))
                {
                    handShakeBool[1] = !Device.GetPress(SteamVR_Controller.ButtonMask.Trigger);
                    if (Device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) {
                        Vector2 pos = Device.GetAxis();
                        float a = pos.y / pos.x;
                        int i = (a <= 1 && a > -1) ? ((pos.x >= 0) ? 0 : 3) : ((pos.y >= 0) ?2:4);
                        handShakeBool[i] = !handShakeBool[i];
                    }
                }
                if (!Device.GetPress(SteamVR_Controller.ButtonMask.Grip)) {
                    MakeOpenHandShakeArray();
                }
                HandShake(handShakeBool, t);
            }

        }
    }
    private void HandShake(bool[] handShakeBool,int r) {
        for (int i = 0; i < 5; i++) {
            for (int t = 0; t < 3; t++)
            {
                SetBoneLocalRotation(HandBone[r][3 * i + t], handShakeBool[i] ? hr[2*r][i][t]:hr[2*r+1][i][t]);
            }
        }
    }
    private void SetBoneLocalRotation(HumanBodyBones bone,Vector3 eulerRotation) {
        var r=animator.GetBoneTransform(bone).eulerAngles;
        animator.SetBoneLocalRotation(bone, Quaternion.Euler(r+(eulerRotation-r).normalized*BoneMoveSpeed));
    }
    private void debug(string str) {
        Debug.Log(str);
    }
}
