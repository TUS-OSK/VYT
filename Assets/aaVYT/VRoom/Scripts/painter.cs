using UnityEngine;

public class painter : HandEvent {
    public GameObject prefab;
    private void FixedUpdate()
    {

    }
    private void Paint() {
        Instantiate(prefab,transform.position,transform.rotation);
    }
}
