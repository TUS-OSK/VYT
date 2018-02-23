using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class WWWSample : MonoBehaviour {
    [SerializeField]
    private string link;
	void Start () {
        var result=ObservableWWW.Get(link);
        result.Subscribe(msg=>Debug.Log(msg));
	}
}
