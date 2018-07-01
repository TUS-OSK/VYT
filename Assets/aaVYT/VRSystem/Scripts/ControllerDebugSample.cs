using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

public class ControllerDebugSample : VRObjectBase
{
    private bool IsAttached;
    void FixedUpdate()
    {
        if (Device != null)
        {
            if (Device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("トリガーを浅く引いた");
            }
            if (Device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("トリガーを深く引いた");
            }
            if (Device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("トリガーを離した");
            }
            if (Device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Debug.Log("タッチパッドをクリックした");
            }
            if (Device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Debug.Log("タッチパッドをクリックしている");
            }
            if (Device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Debug.Log("タッチパッドをクリックして離した");
            }
            if (Device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Debug.Log("タッチパッドに触った");
            }
            if (Device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Debug.Log("タッチパッドを離した");
            }
            if (Device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                Debug.Log("メニューボタンをクリックした");
            }
            if (Device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                Debug.Log("グリップボタンをクリックした");
            }

            if (Device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("トリガーを浅く引いている");
                float value = Device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;
                Debug.Log("トリガーが" + value * 100 + "%押されている");
            }
            if (Device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("トリガーを深く引いている");
                float value = Device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;
                Debug.Log("トリガーが" + value * 100 + "%押されている");
            }
            if (Device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Debug.Log("タッチパッドに触っている");
                Vector2 position = Device.GetAxis();
                Debug.Log("x: " + position.x + " y: " + position.y + "らへんを触っている");
            }
        }
    }
}
