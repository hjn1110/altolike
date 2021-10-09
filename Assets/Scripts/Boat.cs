using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Boat : MonoBehaviour
{
    [ReadOnly][Range(0f, 1f)]
    public float TimeNow;

    [ReadOnly]
    public float t;

    public Transform boatTrans;
    private float defaultY;
    public TrailRenderer[] trais;

    public Color Light1 = new Color(100,155,180);
    public Color Light2;
    public Color Light3;
    public Color Light4;

    public Color GlobalLight1 = new Color(57, 95, 140);
    public Color GlobalLight2;
    public Color GlobalLight3;
    public Color GlobalLight4;

    public SpriteRenderer[] fogs;

    [Range(0f, 1f)]
    public float alpha1 = 1;
    [Range(0f, 1f)]
    public float alpha2 = 1;
    [Range(0f, 1f)]
    public float alpha3 = 1;
    [Range(0f, 1f)]
    public float alpha4 = 1;



    void Start()
    {
        defaultY = boatTrans.position.y;
        StartCoroutine(TimePass());


    }

    public float start = -10;
    public float end = 10;
    public float currentX = -10;
    public float speed = 1f;
    //private float direction = 1;
    public bool move = true;
    public bool colorChange = true;

    public Light2D globalLight;
    public Light2D pointLight;


    

    void ColorChange()
    {

        if (TimeNow >= 0 && TimeNow < 0.25)
        {
            t = (TimeNow - 0)/0.25f;
            pointLight.color = Color.Lerp(Light1, Light2, t);
            globalLight.color = Color.Lerp(GlobalLight1, GlobalLight2, t);
           


        }
        if (TimeNow >= 0.25 && TimeNow < 0.5)
        {
            t = (TimeNow - 0.25f)/0.25f;
            pointLight.color = Color.Lerp(Light2, Light3, t);
            globalLight.color = Color.Lerp(GlobalLight2, GlobalLight3, t);
            

        }
        if (TimeNow >= 0.5 && TimeNow < 0.75)
        {
            t = (TimeNow - 0.5f)/0.25f;
            pointLight.color = Color.Lerp(Light3, Light4, t);
            globalLight.color = Color.Lerp(GlobalLight3, GlobalLight4, t);
           

        }
        if (TimeNow >= 0.75 && TimeNow <= 1)
        {
            t = (TimeNow - 0.75f)/0.25f;
            pointLight.color = Color.Lerp(Light4, Light1, t);
            globalLight.color = Color.Lerp(GlobalLight4, GlobalLight1, t);
           

        }

    }


    IEnumerator TimePass()
    {
        while (move)
        {
            TimeNow = (currentX - start) / (end - start);
            if (currentX < start)
            {
                //direction = 1;
            }
            if (currentX > end)
            {
                //direction = -1;
                currentX = start;
                boatTrans.position = new Vector3(currentX, defaultY, 0);
                foreach (TrailRenderer trai in trais)
                    trai.Clear();
            }
            currentX += Time.deltaTime * speed;
            boatTrans.position = new Vector3(currentX, defaultY, 0);
            yield return null;
        }
        
    }

    private void FixedUpdate()
    {

    }
    void Update()
    {
        //Invoke(nameof(TimePass), 0.01f);

        if (Time.frameCount % 2 == 0)
        {
            ColorChange();
        }

    }
}
