using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightHand : handEvent {
    [SerializeField]
    private GameObject lightobj;

	void Update () {
		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            lightobj.SetActive(true);
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            lightobj.SetActive(false);
        }
	}
}
