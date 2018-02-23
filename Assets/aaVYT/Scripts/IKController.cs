using UnityEngine;
using System;
using System.Collections;

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
            MainObj.transform.position = new Vector3(Head.transform.position.x,MainObj.transform.position.y,Head.transform.position.z);
        }
    }
    void OnAnimatorIK()
    {
        if (center != null) {
            transform.localPosition = new Vector3(center.transform.position.x , center.transform.position.y, center.transform.position.z);
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
    }
}