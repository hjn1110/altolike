using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowController : MonoBehaviour
{

    [ColorUsage(false, true)]
    public Color glowColor;

    [HideInInspector]
    public Material glowMa;
     
    private void Start()
    {
        initGlowMa();
        initBloom();
    }

    public virtual void initGlowMa()
    {
        glowMa = GetComponent<Renderer>().material;

    }

    public virtual void initBloom()
    {
        glowMa.SetColor("Color_9EE04840", glowColor);
    }


}
