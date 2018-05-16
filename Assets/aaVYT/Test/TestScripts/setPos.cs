using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPos : MonoBehaviour {
    [SerializeField]
    private GameObject head;
	void Start () {
        var p=transform.position;
        transform.position = new Vector3(head.transform.position.x,p.y, head.transform.position.z);
        transform.rotation = Quaternion.Euler(0,head.transform.eulerAngles.y,0);
	}
	
}
