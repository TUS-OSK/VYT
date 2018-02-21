using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightHand : HandEvent {
    [SerializeField]
    private GameObject lightobj;

	void Update () {
		if (Device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            lightobj.SetActive(true);
        }
        if (Device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            lightobj.SetActive(false);
        }
	}
}
