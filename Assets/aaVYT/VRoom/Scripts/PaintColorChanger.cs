using UnityEngine;
public class PaintColorChanger : HandEvent {
    [SerializeField]
    private Painter Painter;
    protected override void GetTouchpadTouch(Vector2 axis)
    {
        float angle = Mathf.Atan2(axis.y,axis.x) * 360.0f / (2 * Mathf.PI);
        float radius = axis.sqrMagnitude;
        float height = 1.0f;
        Painter.ChangeColor(new Vector3(angle,radius,height));
    }
}
