using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LeftHand : handEvent {
    void Update() {
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            SceneManager.LoadSceneAsync("Main");
        }
    }
}
