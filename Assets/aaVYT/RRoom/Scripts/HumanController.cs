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
    [SerializeField]
    private Vector3 HeadLocalRotation;
    [SerializeField]
    private Vector3 RightHandLocalRotation;
    [SerializeField]
    private Vector3 LeftHandLocalRotation;
    [SerializeField]
    private bool Move;
    [SerializeField]
    private GameObject Player;
    private void Start()
    {
        MoveSet(Move);
    }
    private void Update()
    {
        if (Move)
        {
            SetHeadTransform();
            SetRightHandTransform();
            SetLeftHandTransform();
        }
    }
    private void SetHeadTransform() {
        HeadObj.transform.localRotation = Head.transform.localRotation;
    }
    private void SetRightHandTransform() {
        RightHandObj.transform.localRotation = tyousei(RightHand.transform.localEulerAngles);
    }
    private void SetLeftHandTransform() {
        LeftHandObj.transform.localRotation = tyousei(LeftHand.transform.localEulerAngles);
    }
    public void MoveSet(bool move) {
        Move = move;
        //Player.transform.SetPositionAndRotation(transform.position,transform.rotation);
        HeadObj.transform.localRotation = Quaternion.Euler(HeadLocalRotation);
        RightHandObj.transform.localRotation = Quaternion.Euler(RightHandLocalRotation);
        LeftHandObj.transform.localRotation = Quaternion.Euler(LeftHandLocalRotation);
        Update();
    }
    private Quaternion tyousei(Vector3 r) {
        return Quaternion.Euler(new Vector3(-r.x,r.y,r.z));
    }
}
