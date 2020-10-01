using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RefreshText : MonoBehaviour
{
    [Header("Blue Part")]
    public Text[] text_BluePart;

    [Header("White Part")]
    public Text[] text_WhitePart;

    void OnEnable()
    {
        EventManager.StartListening("refreshText", function_RefreshingText);
    }

    void OnDisable()
    {
        EventManager.StopListening("refreshText", function_RefreshingText);
    }

    void Start()
    {
        EventManager.TriggerEvent("refreshText");
    }

    public void function_RefreshingText()
    {
        for(int i = 0; i < text_BluePart.Length; i++)
        {
            if(text_BluePart[i].text == "" || text_BluePart[i].text == "Empty*")
            {
                text_BluePart[i].text = "Empty*";
                text_BluePart[i].color = Color.red;
            }
            else
            {
                text_BluePart[i].color = Color.white;
            }
        }
        for (int i = 0; i < text_WhitePart.Length; i++)
        {
            if (text_WhitePart[i].text == "" || text_WhitePart[i].text == "Empty*")
            {
                text_WhitePart[i].text = "Empty*";
                text_WhitePart[i].color = Color.red;
            }
            else
            {
                text_WhitePart[i].color = Color.black;
            }
        }
    }
}
