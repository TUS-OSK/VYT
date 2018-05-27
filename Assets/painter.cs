using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class painter : HandEvent {
    public TrailRenderer tra;
    private void FixedUpdate()
    {
        tra.enabled = Device.GetPress(SteamVR_Controller.ButtonMask.Grip);
    }
}
