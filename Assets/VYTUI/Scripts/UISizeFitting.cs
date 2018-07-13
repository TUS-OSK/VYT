using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CurvedUI.CurvedUIVertexEffect))]
public class UISizeFitting : MonoBehaviour {

    public FitType fitType;

    private static Vector2 UIPanel = new Vector2(3500,1000);

    private float panelWidth;
    private float panelHeight;

    public float specifiedWidth;
    public float specifiedHeight;    

	public void Start()
    {
        if (this.transform.parent.name == "PanelManager") return;

        //Panelの大きさ取得
        RectTransform parRect = this.transform.parent.gameObject.GetComponent<RectTransform>();
        //Debug.Log(parRect.offsetMax.x +" " + parRect.offsetMin.x + " " + parRect.offsetMax.y + " " + parRect.offsetMin.y);
        panelWidth = UIPanel.x - (-parRect.offsetMax.x + parRect.offsetMin.x);
        panelHeight = UIPanel.y - (-parRect.offsetMax.y + parRect.offsetMin.y);
        Debug.Log(this.transform.parent.name + panelWidth + ":" + panelHeight);

        switch (fitType)
        {
            case FitType.FitToPanelSize:
                SizeFitting(panelWidth, panelHeight);
                break;
            case FitType.FitWidthToPanelSize:
                SizeFitting(panelWidth, -1);
                break;
            case FitType.FitHeightToPanelSize:
                SizeFitting(-1, panelHeight);
                break;
            case FitType.FitToSpecifiedSize:
                SizeFitting(specifiedWidth, specifiedHeight);
                break;
            case FitType.FitToSpecifiedRatio:
                RatioFitting(specifiedWidth, specifiedHeight);
                break;
        }
    }

    void SizeFitting(float w, float h)
    {
        //UIの大きさ設定
        RectTransform rect = this.gameObject.GetComponent<RectTransform>();

        if (w == -1) w = rect.sizeDelta.x;
        if (h == -1) h = rect.sizeDelta.y;

        rect.sizeDelta = new Vector2(w, h);
    }

    void RatioFitting(float w,float h)
    {
        //UIの大きさ設定
        RectTransform rect = this.gameObject.GetComponent<RectTransform>();

        if (w == 0 || h == 0)
        {
            rect.sizeDelta = new Vector2(panelWidth, panelHeight);
            return;
        }

        float ratio = w / h;
        if (panelWidth / panelHeight >= ratio)
        {
            SizeFitting(panelHeight * ratio, panelHeight);
        }
        else
        {
            SizeFitting(panelWidth, panelWidth / ratio);
        }
    }
}

public enum FitType
{
    DontFit,
    FitToPanelSize,
    FitWidthToPanelSize,
    FitHeightToPanelSize,
    FitToSpecifiedRatio,
    FitToSpecifiedSize,
}
