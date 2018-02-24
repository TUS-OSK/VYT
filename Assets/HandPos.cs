using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPos : MonoBehaviour {
    [SerializeField]
    private GameObject target;
	void Update () {
        Vector3 pos = target.transform.position;
        transform.position = new Vector3(pos.x,pos.y-2.81f,pos.z);
	}
}
