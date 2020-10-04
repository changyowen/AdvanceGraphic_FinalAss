using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowLightning : MonoBehaviour
{
    public Light[] lightObject;
    public bool useRainbowColors = true;
    public Gradient colorGradient;
    public float duration = 20.0F;

    void Update()
    {
        if (useRainbowColors == true)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            for (int i = 0; i < lightObject.Length; i++)
            {
                lightObject[i].color = colorGradient.Evaluate(lerp);
            }
        }
        else
        {
            for(int i = 0; i < lightObject.Length; i++)
            {
                lightObject[i].color = Color.white;
            }
        }
    }
}
