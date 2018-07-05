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
    private Vector3 rgb;
    private TrailRenderer trailRenderer;
    private float MaxWidth;
    private List<GameObject> PaintsObjects;

    private void Awake()
    {
        PaintsObjects = new List<GameObject>();
    }
    public void ChangeColor(Vector3 value) {
        rgb = value;
    }
    protected override void GetTriggerPressDown()
    {
        PaintStart();
    }
    protected override void GetTriggerTouch(float value)
    {
        ScaleChange(value);
        PosSet();
    }
    protected override void GetTriggerPress(float value)
    {
        ScaleChange(value);
        PosSet();
    }
    private void PosSet() {
        if (!isPainting) return;
        paintObj.transform.position = paintPoint.transform.position;
    }
    protected override void GetTriggerTouchUp()
    {
        if (isPainting) {
            PaintStop();
        }
    }
    protected override void GetTouchpadPressDown()
    {
        Undo();
    }

    private void PaintStart() {
        if (isPainting) return;
        paintObj = Instantiate(prefab,paintPoint.transform.position,paintPoint.transform.rotation);
        //paintObj.transform.parent = paintPoint.transform;
        trailRenderer = paintObj.GetComponent<TrailRenderer>();
        trailRenderer.startColor = new Color(rgb.x, rgb.y, rgb.z);
        trailRenderer.endColor = new Color(rgb.x, rgb.y, rgb.z);
        trailRenderer.Clear();
        MaxWidth = paintObj.GetComponent<TrailRenderer>().startWidth;
        isPainting = true;
    }
    protected void PaintStop()
    {
        //paintObj.transform.parent = null;
        PaintsObjects.Add(paintObj);
        paintObj = null;
        isPainting = false;
    }
    private void ScaleChange(float value) {
        if (isPainting) {
            //paintObj.GetComponent<TrailRenderer>().widthMultiplier = value * MaxWidth;
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
