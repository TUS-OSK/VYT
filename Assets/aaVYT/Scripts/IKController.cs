using UnityEngine;
using System;
using System.Collections;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Animator))]

public class IKController : MonoBehaviour
{

    protected Animator animator;
    public Transform center;
    public bool ikActive;
    public Transform rightHandObj;
    public Transform leftHandObj;
    public Transform rightFootObj;
    public Transform leftFootObj;
    public GameObject lookObj;

    public Transform center2;
    public Transform rightHandObj2;
    public Transform leftHandObj2;
    public Transform rightFootObj2;
    public Transform leftFootObj2;
    public GameObject lookObj2;
    public GameObject Head;
    public GameObject MainObj;
    public Hand rightHand;
    public Hand leftHand;
    [SerializeField]
    private Vector3[] rightOpenRotate,rightCloseRotate,leftOpenRotate,leftCloseRotate;
    
    private float x;
    private float z;
    [SerializeField]
    private HumanBodyBones[] rightHandBone;
    [SerializeField]
    private HumanBodyBones[] leftHandBone;
    [SerializeField]
    private GameObject Tracker;
    private void Start()
    {
        x = transform.localPosition.x;
        z = transform.localPosition.z;
        animator = GetComponent<Animator>();
        if (!lookObj.activeInHierarchy)
        {
            center = center2;
            rightHandObj = rightHandObj2;
            leftHandObj = leftHandObj2;
            rightFootObj = rightFootObj2;
            leftFootObj = leftFootObj2;
            lookObj = lookObj2;
        }
        else
        {
            //MainObj.transform.position = new Vector3(MainObj.transform.position.x, MainObj.transform.position.y, Head.transform.position.z);
        }
        
    }
    void OnAnimatorIK()
    {
        /////////////*
        ////////////if (center != null)
        ////////////{
        ////////////    var p = center.transform.position;
        ////////////    transform.localPosition = new Vector3(p.x,transform.localPosition.y,p.z); ;
        ////////////}
        ////////////if (Tracker.GetComponent<SteamVR_TrackedObject>().isValid) {
        ////////////    var p = Tracker.transform.position;
        ////////////    transform.position =new Vector3(0,transform.position.y,p.z);
        ////////////}*/
        //transform.localRotation = Quaternion.Euler(0,center.eulerAngles.y,0);
        if (animator)
        {
            if (ikActive)
            {
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.transform.position);
                }
                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }
                if (leftHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                }
                if (rightFootObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootObj.rotation);
                }
                if (leftFootObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootObj.rotation);
                }
            }
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);

                animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);
                animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);
                animator.SetLookAtWeight(0);
            }
        }
        Hand[] hands = new Hand[2];
        hands[0] = rightHand;
        hands[1] = leftHand;
        for (int t = 0; t <= 1; t++) {
            if (hands[t].controller != null)
            {
                var Device = hands[t].controller;
                bool[] handShakeBool = new bool[5];
                if (Device.GetPress(SteamVR_Controller.ButtonMask.Grip))
                {
                    if (!Device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
                    {
                        handShakeBool[1] = true;
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        handShakeBool[i] = true;
                    }
                }
                HandShake(handShakeBool, t == 0);
            }
        }
    }


    private void HandShake(bool[] handShakeBool,bool right) {
        if (handShakeBool.Length != 5) {
            Debug.LogError("指の数おかしいよ");
        }
        HumanBodyBones[][] te = new HumanBodyBones[2][];
        te[0] = rightHandBone;
        te[1] = leftHandBone;
        int r = right ? 0 : 1;
        for (int i = 0; i < 5; i++) {
            for (int t = 0; t < 3; t++)
            {
                Vector3 q = handShakeBool[i] ? (right ? rightOpenRotate[t] : leftOpenRotate[t]) : (right ? rightCloseRotate[t] : leftCloseRotate[t]);
                if (i == 0)
                {
                    q = handShakeBool[i] ? (!right ? rightOpenRotate[t] : leftOpenRotate[t]) : (!right ? rightCloseRotate[t] : leftCloseRotate[t]);
                }
                BoneRotate(te[r][3 * i + t], q);
            }
        }
        
    }
    private void BoneRotate(HumanBodyBones bone,Vector3 eulerRotation) {
        animator.SetBoneLocalRotation(bone, Quaternion.Euler(eulerRotation));
    }
}
