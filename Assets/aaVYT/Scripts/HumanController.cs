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

   
    private void Update()
    {
        SetHeadTransform();
        SetRightHandTransform();
        SetLeftHandTransform();
    }
    private void SetHeadTransform() {
        HeadObj.transform.localRotation = Head.transform.localRotation;
    }
    private void SetRightHandTransform() {
        RightHandObj.transform.localRotation = RightHand.transform.localRotation;
    }
    private void SetLeftHandTransform() {
        LeftHandObj.transform.localRotation = LeftHand.transform.localRotation;
    }
}
