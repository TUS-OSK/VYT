using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour {
    [SerializeField]
    private Transform Head;
    [SerializeField]
    private Transform RightHand;
    [SerializeField]
    private Transform LeftHand;
    [SerializeField]
    private GameObject HeadObj;
    [SerializeField]
    private GameObject RightHandObj;
    [SerializeField]
    private GameObject LeftHandObj;

    private Vector3 HeadLocalPos;
    private Vector3 RightHandLocalPos;
    private Vector3 LeftHandLocalPos;

    private void Start()
    {
        HeadLocalPos = HeadObj.transform.localPosition;
        RightHandLocalPos = RightHandObj.transform.localPosition;
        LeftHandLocalPos = LeftHandObj.transform.localPosition;
        transform.rotation = Quaternion.Euler(0,Head.transform.eulerAngles.y,0);
    }
    private void Update()
    {
        SetHeadTransform();
        SetRightHandTransform();
        SetLeftHandTransform();
    }
    private void SetHeadTransform() {
        HeadObj.transform.SetPositionAndRotation(transform.position+HeadLocalPos,Head.transform.localRotation);
    }
    private void SetRightHandTransform() {
        RightHandObj.transform.SetPositionAndRotation(transform.position + RightHandLocalPos, RightHand.transform.localRotation);
    }
    private void SetLeftHandTransform() {
        LeftHandObj.transform.SetPositionAndRotation(transform.position + LeftHandLocalPos, LeftHand.transform.localRotation);
    }
}
