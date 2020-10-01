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
    public GameObject Skill_anchorPoint, workingExperience_obj, personalSkill_obj, workingButton, skillButton;

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

        RefreshPosition();
    }

    void RefreshPosition()
    {
        RectTransform anchorRect = Skill_anchorPoint.GetComponent<RectTransform>();
        RectTransform WE_objRect = workingExperience_obj.GetComponent<RectTransform>();
        RectTransform PS_objRect = personalSkill_obj.GetComponent<RectTransform>();
        RectTransform workingButtonRect = workingButton.GetComponent<RectTransform>();
        RectTransform skillButtonRect = skillButton.GetComponent<RectTransform>();

        Vector2 newTextSize = new Vector2(WE_objRect.rect.width, text_WhitePart[11].preferredHeight);
        WE_objRect.sizeDelta = newTextSize;
        workingButtonRect.sizeDelta = newTextSize;
        newTextSize = new Vector2(PS_objRect.rect.width, text_WhitePart[12].preferredHeight);
        PS_objRect.sizeDelta = newTextSize;
        skillButtonRect.sizeDelta = newTextSize;

        Vector3 newPosition = new Vector3(anchorRect.anchoredPosition.x, WE_objRect.rect.height * -1);
        anchorRect.anchoredPosition = newPosition;
    }
}
