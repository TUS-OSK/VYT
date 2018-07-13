using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorTest : MonoBehaviour {
    private Material mat;
    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
    }
    void ChangeColor() {
        Vector3 rgb = HSLColor.HSLtoRGB(transform.eulerAngles.y,2 - transform.localScale.x ,transform.position.y);
        mat.color = new Color(rgb.x,rgb.y,rgb.z);
    }
    private void Update()
    {
        ChangeColor();
        transform.eulerAngles = new Vector3(0,Time.time * 20,0);
    }
}
