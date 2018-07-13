using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nose : MonoBehaviour {
    public float kyori;
    public GameObject Camera;
    private MeshRenderer render;
    private void Awake()
    {
        render = GetComponent<MeshRenderer>();
    }
    public void FixedUpdate()
    {
        if ((Camera.transform.position - transform.position).sqrMagnitude <= kyori)
        {
            render.enabled = false;
        }
        else {
            render.enabled = true;
        }
    }
}
