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
    public Transform lookObj;

    private float x;
    private float z;
    private void Start()
    {
        x = transform.localPosition.x;
        z = transform.localPosition.z;
        animator = GetComponent<Animator>();

    }
    void OnAnimatorIK()
    {
        if (center != null) {
            transform.localPosition = new Vector3(center.transform.position.x + x, transform.localPosition.y, center.transform.position.z + z);
        }

        transform.localRotation = Quaternion.Euler(0,center.eulerAngles.y,0);
        if (animator)
        {
            if (ikActive)
            {
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.position);
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