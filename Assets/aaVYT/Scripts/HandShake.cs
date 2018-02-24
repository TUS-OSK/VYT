using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandShake : HandEvent
{
    [SerializeField]
    private GameObject Player;
    private Animator animator;
    private bool right;
    private int startint;
    [SerializeField]
    private Vector3 rotateeuler;
    [SerializeField]
    private Vector3 rotateeuler2;
    private Quaternion magarurotate;
    private Quaternion massugurotate;
    private void Start()
    {
        animator = Player.GetComponent<Animator>();
        startint = 24;
        if (right)
        {
            startint += 15;
        }
        magarurotate = Quaternion.Euler(rotateeuler);
        massugurotate = Quaternion.Euler(rotateeuler2);
    }
    private void Update()
    {
        if (!right)
        {
            if (Device.GetPress(SteamVR_Controller.ButtonMask.Grip))
            {
                if (Device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
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
                if (Device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    Vector2 position = Device.GetAxis();
                    float a = position.y / position.x;
                    if (a > -1 && a < 1)
                    {
                        if (position.x >= 0)
                        {
                            //右
                        }
                        else
                        {
                            //左
                        }
                    }
                    else
                    {
                        if (position.y >= 0)
                        {
                            //上
                        }
                        else
                        {
                            //下
                        }
                    }
                }
            }
            else {
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
        else
        {
            if (Device.GetPress(SteamVR_Controller.ButtonMask.Grip))
            {
                if (Device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
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
                }//人差し指だけ

                if (Device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    Vector2 position = Device.GetAxis();
                    float a = position.y / position.x;
                    if (a > -1 && a < 1)
                    {
                        if (position.x >= 0)
                        {
                            //右
                        }
                        else
                        {
                            //左
                        }
                    }
                    else
                    {
                        if (position.y >= 0)
                        {
                            //上
                        }
                        else
                        {
                            //下
                        }
                    }
                }
            }
            else {
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

        startint = 24;
        if (right)
        {
            startint += 15;
        }
    }
}