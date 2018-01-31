using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UniRx;

[RequireComponent(typeof(Hand))]
public abstract class handEvent : MonoBehaviour {
    protected Hand hand { get; private set; }
    protected SteamVR_Controller.Device device { get; private set; }

    void Start() {
        hand = GetComponent<Hand>();
        device = hand.controller;
    }
}