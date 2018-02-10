using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : handEvent {
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject pa;

    void Update() {
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector2 position = device.GetAxis();
            pa.transform.position = pa.transform.position + new Vector3(position.x, 0, position.y).normalized * speed;
        }
    }
}
