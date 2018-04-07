using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koessaisei : MonoBehaviour {
    [SerializeField]
    private AudioSource[] koes;
    [SerializeField]
    private float WaitTime;
	// Use this for initialization
	void Start () {
        Invoke("Saisei",WaitTime);
		
	}
    private void Saisei() {
        foreach(var koe in koes)
        {
            koe.Play();
        }
    }
}
