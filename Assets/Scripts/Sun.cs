using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Sun : MonoBehaviour
{
    float a;
    float c = 6f;
    float b = 3f;
    


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
    GlowController glowController;

    public SpriteRenderer sky;

    public Light2D global2D;

    [ColorUsage(false)]
    public Color DawnLight = new Color(119, 152, 105);
    
    [ColorUsage(false)]
    public Color NoonLight = new Color(233, 233, 122);
    [ColorUsage(false)]
    public Color DuskLight = new Color(180,100,100);
    [ColorUsage(false)]
    public Color NightLight = new Color(0, 0, 0);

    public float DawnLightI = 0.2f;
    public float NoonLightI = 0.8f;
    public float DuskLightI = 1.2f;
    public float NightLightI = 0f;

    [ColorUsage(false)]
    public Color DawnGlobal = new Color(100, 119, 180);
    [ColorUsage(false)]
    public Color NoonGlobal = new Color(100, 119, 180);
    [ColorUsage(false)]
    public Color DuskGlobal = new Color(100, 119, 180);
    [ColorUsage(false)]
    public Color NightGlobal = new Color(100, 119, 180);

    public float DawnGlobalI = 0.5f;
    public float NoonGlobalI = 1f;
    public float DuskGlobalI = 0.5f;
    public float NightGlobalI = 0f;

    public float intensity = 2f;
    float factor;
    [ColorUsage(false,true)]
    public Color DawnSunGlow = new Color(191, 56,94);
    [ColorUsage(false,true)]
    public Color NoonSunGlow = new Color(191, 56, 94);
    [ColorUsage(false,true)]
    public Color DuskSunGlow = new Color(191, 56, 94);
    [ColorUsage(false,true)]
    public Color NightSunGlow = new Color(191, 56, 94);

    [ColorUsage(false)]
    public Color DawnSky = new Color(16, 19,31);
    [ColorUsage(false)]
    public Color NoonSky = new Color(16, 19,31);
    [ColorUsage(false)]
    public Color DuskSky = new Color(16, 19, 31);
    [ColorUsage(false)]
    public Color NightSky = new Color(16, 19, 31);

    private void Start()
    {
        factor = Mathf.Pow(2, intensity);
        
        sunTrans = sun.transform;
        glowController = sun.GetComponent<GlowController>();


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
            float t = (TimeNow - 6) / 6;
            light2D.color = Color.Lerp(DawnLight, NoonLight, t);
            light2D.intensity = Mathf.Lerp(DawnLightI, NoonLightI, t);
            global2D.color = Color.Lerp(DawnGlobal,NoonGlobal,t);
            global2D.intensity = Mathf.Lerp(DawnGlobalI, NoonGlobalI, t);
            Color glow = Color.Lerp(DawnSunGlow, NoonSunGlow, t);
            glow = new Color(glow.r, glow.g , glow.b, 0);
            glowController.glowColor = glow;
            sky.color = Color.Lerp(DawnSky, NoonSky, t);

        }
        if ((TimeNow >= 12) && (TimeNow < 18))
        {
            float t = (TimeNow - 12) / 6;
            light2D.color = Color.Lerp(NoonLight, DuskLight, t);
            light2D.intensity = Mathf.Lerp(NoonLightI, DuskLightI, t);
            global2D.color = Color.Lerp(NoonGlobal, DuskGlobal, t);
            global2D.intensity = Mathf.Lerp(NoonGlobalI, DuskGlobalI, t);
            Color glow = Color.Lerp(NoonSunGlow, DuskSunGlow, t);
            glow = new Color(glow.r, glow.g, glow.b, 0);
            glowController.glowColor = glow;
            sky.color = Color.Lerp(NoonSky, DuskSky, t);


        }
        if ((TimeNow >= 18) && (TimeNow < 24))
        {
            float t = (TimeNow - 18) / 6;
            light2D.color = Color.Lerp(DuskLight, NightLight, t);
            light2D.intensity = Mathf.Lerp(DuskLightI, NightLightI, t);
            global2D.color = Color.Lerp(DuskGlobal, NightGlobal, t);
            global2D.intensity = Mathf.Lerp(DuskGlobalI, NightGlobalI, t);
            Color glow = Color.Lerp(DuskSunGlow, NightSunGlow, t);
            glow = new Color(glow.r, glow.g, glow.b, 0);
            glowController.glowColor = glow;
            sky.color = Color.Lerp(DuskSky, NightSky, t);


        }
        if ((TimeNow >= 0) && (TimeNow < 6))
        {
            float t = (TimeNow - 0) / 6;
            light2D.color = Color.Lerp(NightLight, DawnLight, t);
            light2D.intensity = Mathf.Lerp(NightLightI, DawnLightI, t);
            global2D.color = Color.Lerp(NightGlobal, DawnGlobal, t);
            global2D.intensity = Mathf.Lerp(NightGlobalI, DawnGlobalI, t);
            Color glow = Color.Lerp(NightSunGlow, DawnSunGlow, t);
            glow = new Color(glow.r, glow.g, glow.b, 0);
            glowController.glowColor = glow;
            sky.color = Color.Lerp(NightSky, DawnSky, t);


        }

    }


    private void Update()
    {
        SunMove();
        LightChange();

    }








}
