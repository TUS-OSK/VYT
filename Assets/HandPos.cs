using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPos : MonoBehaviour {
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Vector3 Sabun;
	void Update () {
        Vector3 pos = target.transform.position;
        transform.position = pos + Sabun;
        transform.rotation = target.transform.rotation;
	}
}
