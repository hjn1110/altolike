using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowController : MonoBehaviour
{
    
    public Color glowColor { set { _glowColor = value; initBloom(); } get { return _glowColor; } }
    [ColorUsage(false, true)]
    public Color _glowColor;
    
    /*
    [ColorUsage(false, true)]
    public Color glowColor;
    */

    [HideInInspector]
    public Material glowMa;
     
    private void Start()
    {
        initGlowMa();
        initBloom();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            initBloom();
            Debug.Log(glowColor);
        }
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
