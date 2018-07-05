using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UniRx;
using UniRx.Triggers;

[RequireComponent(typeof(Hand))]
public abstract class HandEvent : MonoBehaviour
{
    private Hand Hand
    {
        get
        {
            return GetComponent<Hand>();
        }
    }
    private SteamVR_Controller.Device Device
    {
        get
        {
            return Hand.controller;
        }
    }
    private float TriggerValue
    {
        get
        {
            return Device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;
        }
    }
    private Vector2 TouchpadAxis
    {
        get
        {
            return Device.GetAxis();
        }
    }

    void FixedUpdate()
    {
        if (Device != null)
        {
            if (Device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                GetTriggerTouchDown(TriggerValue);
            }
            if (Device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
            {
                GetTriggerTouch(TriggerValue);
            }
            if (Device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                GetTriggerTouchUp(TriggerValue);
            }

            if (Device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                GetTriggerPressDown(TriggerValue);
            }
            if (Device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                GetTriggerPress(TriggerValue);
            }
            if (Device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                GetTriggerPressUp(TriggerValue);
            }

            if (Device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                GetTouchpadTouchDown(TouchpadAxis);
            }
            if (Device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {
                GetTouchpadTouch(TouchpadAxis);
            }
            if (Device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                GetTouchpadTouchUp(TouchpadAxis);
            }

            if (Device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                GetTouchpadPressDown(TouchpadAxis);
            }
            if (Device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                GetTouchpadPress(TouchpadAxis);
            }
            if (Device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                GetTouchpadPressUp(TouchpadAxis);
            }
            
            if (Device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                GetMenuPressDown();
            }
            if (Device.GetPress(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                GetMenuPress();
            }
            if (Device.GetPressUp(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                GetMenuPressUp();
            }
            if (Device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                GetGripPressDown();
            }
            if (Device.GetPress(SteamVR_Controller.ButtonMask.Grip))
            {
                GetGripPress();
            }
            if (Device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
            {
                GetGripPressUp();
            } 
        }
    }
    
    protected virtual void GetTriggerTouchDown(float value)
    {

    }
    protected virtual void GetTriggerTouch(float value)
    {

    }
    protected virtual void GetTriggerTouchUp(float value)
    {

    }
    protected virtual void GetTriggerPressDown(float value)
    {

    }
    protected virtual void GetTriggerPress(float value)
    {

    }
    protected virtual void GetTriggerPressUp(float value)
    {

    }
    protected virtual void GetTouchpadTouchDown(Vector2 axis)
    {

    }
    protected virtual void GetTouchpadTouch(Vector2 axis)
    {

    }
    protected virtual void GetTouchpadTouchUp(Vector2 axis)
    {

    }
    protected virtual void GetTouchpadPressDown(Vector2 axis)
    {

    }
    protected virtual void GetTouchpadPress(Vector2 axis)
    {

    }
    protected virtual void GetTouchpadPressUp(Vector2 axis)
    {

    }
    protected virtual void GetGripPressDown()
    {

    }
    protected virtual void GetGripPress()
    {

    }
    protected virtual void GetGripPressUp()
    {

    }
    protected virtual void GetMenuPressDown()
    {

    }
    protected virtual void GetMenuPress()
    {

    }
    protected virtual void GetMenuPressUp()
    {

    }
}