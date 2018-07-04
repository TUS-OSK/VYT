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
                GetTriggerTouchDown();
            }
            if (Device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
            {
                GetTriggerTouch(TriggerValue);
            }
            if (Device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                GetTriggerTouchUp();
            }

            if (Device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                GetTriggerPressDown();
            }
            if (Device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                GetTriggerPress(TriggerValue);
            }
            if (Device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                GetTriggerPressUp();
            }

            if (Device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                GetTouchpadTouchDown();
            }
            if (Device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {
                GetTouchpadTouch(TouchpadAxis);
            }
            if (Device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                GetTouchpadTouchUp();
            }

            if (Device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                GetTouchpadPressDown();
            }
            if (Device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                GetTouchpadPress();
            }
            if (Device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                GetTouchpadPressUp();
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
    
    protected virtual void GetTriggerTouchDown(){

    }
    protected virtual void GetTriggerTouch(float value)
    {

    }
    protected virtual void GetTriggerTouchUp()
    {

    }
    protected virtual void GetTriggerPressDown()
    {

    }
    protected virtual void GetTriggerPress(float value)
    {

    }
    protected virtual void GetTriggerPressUp(){

    }
    protected virtual void GetTouchpadTouchDown()
    {

    }
    protected virtual void GetTouchpadTouch(Vector2 axis)
    {

    }
    protected virtual void GetTouchpadTouchUp()
    {

    }
    protected virtual void GetTouchpadPressDown()
    {

    }
    protected virtual void GetTouchpadPress()
    {

    }
    protected virtual void GetTouchpadPressUp()
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