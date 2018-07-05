using UnityEngine;
public class PaintColorChanger : HandEvent {
    [SerializeField]
    private Painter Painter;
    protected override void GetTouchpadTouch(Vector2 axis)
    {
        float angle =180.0f + Mathf.Atan2(axis.y,axis.x) * 360.0f / (2 * Mathf.PI);
        Debug.Log(angle);
        float radius = 0.5f + axis.sqrMagnitude/2.0f;
        float height = 0.8f;
        Painter.ChangeColor(new Vector3(angle,radius,height));
    }
}
