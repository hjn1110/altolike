using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Sun : MonoBehaviour
{
    float a;
    float c = 6f;
    float b = 4f;


    [Range(0, 2* Mathf.PI+0.1f)]
    public float Angle = 0;
    float _Angle{get{ return Angle + Mathf.PI; }}

    [ReadOnly]
    public float TimeNow;

    float x;
    float y;

    public GameObject sun;
    Transform sunTrans;

    public Light2D light2D;

    [ColorUsage(false)]
    public Color DawnLight = new Color(180, 100, 100);
    [ColorUsage(false)]
    public Color NoonLight = new Color(180, 100, 100);
    [ColorUsage(false)]
    public Color DuskLight = new Color(180,100,100);
    [ColorUsage(false)]
    public Color NightLight = new Color(180, 100, 100);


    private void Start()
    {
        sunTrans = sun.transform;
    }

    private void SunMove()
    {
        a = Mathf.Sqrt(b * b + c * c);

        x = a * Mathf.Cos(_Angle);
        y = -b * Mathf.Sin(_Angle);
        sunTrans.position = new Vector3(x, y, 0);

        if (Angle >= 2 * Mathf.PI)
        {
            Angle = 0;
        }

        TimeNow = (Angle) / Mathf.PI * 12 + 6f;
        if (TimeNow >= 24)
        {
            TimeNow -= 24f;
        }
    }

    private void LightChange()
    {
        

        if ((TimeNow >= 6) && (TimeNow < 12))
        {
            light2D.color = (NoonLight - DawnLight) / 6 * (TimeNow - 6) + DawnLight;
        }
        if ((TimeNow >= 12) && (TimeNow < 18))
        {
            light2D.color = (DuskLight - NoonLight) / 6 * (TimeNow - 12) + NoonLight;
        }
        if ((TimeNow >= 18) && (TimeNow < 24))
        {
            light2D.color = (NightLight - DuskLight) / 6 * (TimeNow - 18) + DuskLight;
        }
        if ((TimeNow >= 0) && (TimeNow < 6))
        {
            light2D.color = (DawnLight - NightLight) / 6 * (TimeNow - 0) + NightLight;
        }
    }


    private void Update()
    {
        SunMove();
        LightChange();

    }








}
