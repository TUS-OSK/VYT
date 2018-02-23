using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foot : MonoBehaviour {
    [SerializeField]
    private Transform center;
    [SerializeField]
    private Transform rotatecenter;
    private float y;
    private void Start()
    {
        y = transform.position.y;

    }
    private void Update()
    {
        transform.localPosition = new Vector3(center.position.x,y,center.position.z);
        transform.localRotation = Quaternion.Euler(0,rotatecenter.eulerAngles.y,0);
    }
}
