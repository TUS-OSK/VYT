using UnityEngine;
public class PaintColorChanger : HandEvent {
    [SerializeField]
    private Painter Painter;
    private float Lightness;

    private void Awake()
    {
        Lightness = 0.5f;
        Painter.ChangeColor(new Vector3(0.0f,0.5f,0.5f));
    }

    protected override void GetTouchpadTouch(Vector2 axis)
    {
        float angle =180.0f + Mathf.Atan2(axis.y,axis.x) * 360.0f / (2 * Mathf.PI);
        float radius = axis.sqrMagnitude;
        float height = Lightness;
        Painter.ChangeColor(HSLColor.HSLtoRGB(angle,radius,height));
    }
    
    /*protected override void GetTouchpadPressDown(Vector2 axis)
    {
        if (axis.y >= 0.2f)
        {
            Lightness += 0.1f;
        }
        else if(axis.y <= 0.2f){
            Lightness -= 0.1f;
        }
        if (Lightness > 1.0f) Lightness = 1.0f;
        if(Lightness < 0.0f) Lightness = 0.0f;
    }
    */
}
