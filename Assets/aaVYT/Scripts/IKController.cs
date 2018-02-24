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
    private Vector3 rotateeuler;
    [SerializeField]
    private Vector3 rotateeuler2;
    private Quaternion magarurotate;
    private Quaternion massugurotate;
    private float x;
    private float z;
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
            MainObj.transform.position = new Vector3(Head.transform.position.x, MainObj.transform.position.y, Head.transform.position.z);
        }

        magarurotate = Quaternion.Euler(rotateeuler);
        massugurotate = Quaternion.Euler(rotateeuler2);
    }
    void OnAnimatorIK()
    {
        if (center != null)
        {
            transform.localPosition = new Vector3(center.transform.position.x, center.transform.position.y, center.transform.position.z);
        }
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
        if (rightHand.controller != null)
        {
            var rightDevice = rightHand.controller;
            if (rightDevice.GetPress(SteamVR_Controller.ButtonMask.Grip))
            {
                if (rightDevice.GetPress(SteamVR_Controller.ButtonMask.Trigger))
                {
                    animator.SetBoneLocalRotation(HumanBodyBones.RightThumbProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightThumbIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightThumbDistal, magarurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.RightIndexProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightIndexIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightIndexDistal, magarurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.RightMiddleProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightMiddleIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightMiddleDistal, magarurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.RightRingProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightRingIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightRingDistal, magarurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.RightLittleProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightLittleIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightLittleDistal, magarurotate);
                }
                else
                {
                    animator.SetBoneLocalRotation(HumanBodyBones.RightThumbProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightThumbIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightThumbDistal, magarurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.RightIndexProximal, massugurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightIndexIntermediate, massugurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightIndexDistal, massugurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.RightMiddleProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightMiddleIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightMiddleDistal, magarurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.RightRingProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightRingIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightRingDistal, magarurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.RightLittleProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightLittleIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.RightLittleDistal, magarurotate);
                }
            }
            else
            {
                animator.SetBoneLocalRotation(HumanBodyBones.RightThumbProximal, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.RightThumbIntermediate, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.RightThumbDistal, massugurotate);

                animator.SetBoneLocalRotation(HumanBodyBones.RightIndexProximal, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.RightIndexIntermediate, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.RightIndexDistal, massugurotate);

                animator.SetBoneLocalRotation(HumanBodyBones.RightMiddleProximal, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.RightMiddleIntermediate, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.RightMiddleDistal, massugurotate);

                animator.SetBoneLocalRotation(HumanBodyBones.RightRingProximal, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.RightRingIntermediate, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.RightRingDistal, massugurotate);

                animator.SetBoneLocalRotation(HumanBodyBones.RightLittleProximal, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.RightLittleIntermediate, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.RightLittleDistal, massugurotate);
            }
        }
        if (leftHand.controller != null)
        {
            var leftDevice = rightHand.controller;
            if (leftDevice.GetPress(SteamVR_Controller.ButtonMask.Grip))
            {
                if (leftDevice.GetPress(SteamVR_Controller.ButtonMask.Trigger))
                {
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftThumbProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftThumbIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftThumbDistal, magarurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.LeftIndexProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftIndexIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftIndexDistal, magarurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.LeftMiddleProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftMiddleIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftMiddleDistal, magarurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.LeftRingProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftRingIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftRingDistal, magarurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.LeftLittleProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftLittleIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftLittleDistal, magarurotate);
                }
                else
                {
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftThumbProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftThumbIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftThumbDistal, magarurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.LeftIndexProximal, massugurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftIndexIntermediate, massugurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftIndexDistal, massugurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.LeftMiddleProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftMiddleIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftMiddleDistal, magarurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.LeftRingProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftRingIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftRingDistal, magarurotate);

                    animator.SetBoneLocalRotation(HumanBodyBones.LeftLittleProximal, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftLittleIntermediate, magarurotate);
                    animator.SetBoneLocalRotation(HumanBodyBones.LeftLittleDistal, magarurotate);
                }
            }
            else
            {
                animator.SetBoneLocalRotation(HumanBodyBones.LeftThumbProximal, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.LeftThumbIntermediate, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.LeftThumbDistal, massugurotate);

                animator.SetBoneLocalRotation(HumanBodyBones.LeftIndexProximal, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.LeftIndexIntermediate, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.LeftIndexDistal, massugurotate);

                animator.SetBoneLocalRotation(HumanBodyBones.LeftMiddleProximal, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.LeftMiddleIntermediate, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.LeftMiddleDistal, massugurotate);

                animator.SetBoneLocalRotation(HumanBodyBones.LeftRingProximal, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.LeftRingIntermediate, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.LeftRingDistal, massugurotate);

                animator.SetBoneLocalRotation(HumanBodyBones.LeftLittleProximal, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.LeftLittleIntermediate, massugurotate);
                animator.SetBoneLocalRotation(HumanBodyBones.LeftLittleDistal, massugurotate);
            }
        }
    }
}