using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UniRx;

[RequireComponent(typeof(Hand))]
public abstract class HandEvent : MonoBehaviour {
    protected Hand Hand { get; private set; }
    protected SteamVR_Controller.Device Device { get; private set; }

    void Start() {
        Hand = GetComponent<Hand>();
        Device = Hand.controller;
    }
}