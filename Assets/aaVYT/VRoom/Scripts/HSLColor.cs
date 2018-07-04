using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HSLColor{
    public static Vector3 HSLtoRGB(float angle,float radius,float height) {
        float L = height;
        float S = radius;
        float value = (S * (1 - Mathf.Abs(2 * L - 1))) / 2.0f;
        float max = L + value;
        float min = L - value;
        float H = angle;
        if (max == min) {
            return new Vector3(max, max, max);
        }
        else if (H >= 0 && H < 60) {
            return new Vector3(max, min + (max - min) * H / 60.0f,min);
        }
        else if (H >= 60 && H < 120)
        {
            return new Vector3(min + (max - min) * (120.0f - H) / 60.0f, max,min);
        }
        else if (H >= 120 && H < 180)
        {
            return new Vector3(min,max,min + (max - min) * (H - 120.0f) / 60.0f);
        }
        else if (H >= 180 && H < 240)
        {
            return new Vector3(min, min + (max - min) * (240.0f - H) / 60.0f ,max);
        }
        else if (H >= 240 && H < 300)
        {
            return new Vector3(min + (max - min) * (H - 240.0f) / 60.0f,min ,max);
        }
        else if (H >= 300 && H < 360)
        {
            return new Vector3(max ,min,min + (max - min) * (360.0f - H) / 60.0f);
        }
        return new Vector3();
    }
}
