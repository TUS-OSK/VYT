using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextScrollDemo : MonoBehaviour {

    private Mask mask;
    private ScrollRect scroll;

	// Use this for initialization
	void Start () {
        RectTransform rect = this.GetComponent<RectTransform>();
        //rect.anchorMax = new Vector2(0.5f, 1);
        //rect.anchorMin = new Vector2(0.5f, 1);
        //rect.localPosition = new Vector3(rect.localPosition.x, -110, rect.localPosition.z);

        mask = this.transform.parent.gameObject.AddComponent<Mask>();
        scroll = this.transform.parent.gameObject.AddComponent<ScrollRect>();
        scroll.horizontal = false;
	}

    void OnDisable()
    {
        DestroyImmediate(mask);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
