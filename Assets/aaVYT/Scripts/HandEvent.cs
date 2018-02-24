using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UniRx;

[RequireComponent(typeof(Hand))]
public abstract class HandEvent : MonoBehaviour {
    protected Hand Hand
    {
        get
        {
            return GetComponent<Hand>();
        }
    }
    protected SteamVR_Controller.Device Device { get {
            return Hand.controller;
        } }

}