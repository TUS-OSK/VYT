using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPos : MonoBehaviour {
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Vector3 Sabun;
	void Update () {
        transform.SetPositionAndRotation(target.transform.position + Sabun, target.transform.rotation);
	}
}
