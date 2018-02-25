using UnityEngine;
using Valve.VR.InteractionSystem;
public class ModelHyouzi : MonoBehaviour {
    [SerializeField]
    private bool ModelDasu;
    private void Start()
    {
        if (!ModelDasu) {
            Destroy(
         GetComponent<SpawnRenderModel>());
        }
    }
}