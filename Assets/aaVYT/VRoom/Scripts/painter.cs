using UnityEngine;
using UniRx;
using System.Collections.Generic;

public class Painter : HandEvent {
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject paintPoint;
    private GameObject paintObj;
    private bool isPainting;
    private ReactiveProperty<Vector3> RGB;
    private Material mat;
    private float MaxWidth;
    private List<GameObject> PaintsObjects;

    private void Awake()
    {
        RGB.Subscribe(value => EditMatColor(value));
        PaintsObjects = new List<GameObject>();
    }
    public void ChangeColor(Vector3 rgb) {
        RGB.Value = rgb;
    }
    private void EditMatColor(Vector3 value) {
        if (!isPainting) return;
        mat.color = new Color(value.x,value.y,value.z);
    }
    protected override void GetTriggerPressDown()
    {
        PaintStart();
    }
    protected override void GetTriggerTouch(float value)
    {
        ScaleChange(value);
    }
    protected override void GetTriggerPress(float value)
    {
        ScaleChange(value);
    }
    protected override void GetTriggerTouchUp()
    {
        if (isPainting) {
            PaintStart();
        }
    }
    protected override void GetTouchpadPressDown()
    {
        Undo();
    }

    private void PaintStart() {
        if (isPainting) return;
        paintObj = Instantiate(prefab,paintPoint.transform.position,paintPoint.transform.rotation);
        paintObj.transform.parent = paintPoint.transform;
        mat = paintObj.GetComponent<MeshRenderer>().material;
        EditMatColor(RGB.Value);
        MaxWidth = paintObj.GetComponent<TrailRenderer>().startWidth;
        isPainting = true;
    }
    protected void PaintStop()
    {
        paintObj.transform.parent = null;
        PaintsObjects.Add(paintObj);
        paintObj = null;
        isPainting = false;
    }
    private void ScaleChange(float value) {
        if (isPainting) {
            paintObj.GetComponent<TrailRenderer>().widthMultiplier = value * MaxWidth;
        }
    }
    private void Undo() {
        if (!isPainting) {
            GameObject RemoveObj = PaintsObjects[PaintsObjects.Count - 1];
            PaintsObjects.Remove(RemoveObj);
            Destroy(RemoveObj);
        }
    }
}
