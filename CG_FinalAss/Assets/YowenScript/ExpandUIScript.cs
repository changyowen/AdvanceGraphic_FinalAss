using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandUIScript : MonoBehaviour
{
    public GameObject ShortIntroduction;
    public Button introButton;
    public Text introText;
    public GameObject ContactAnchorPoint;
    public GameObject ContactMaskContent;

    private bool alreadyExpand_aboutMe = false;
    private bool alreadyExpand_contact = false;
    public Vector2 minimizeSize, maximizeSize, minimizeSize_2, maximizeSize_2;
    RectTransform IntroRect, ContactRect_anchor, ContactRect_mask;

    void Start()
    {
        IntroRect = ShortIntroduction.GetComponent<RectTransform>();
        ContactRect_anchor = ContactAnchorPoint.GetComponent<RectTransform>();
        ContactRect_mask = ContactMaskContent.GetComponent<RectTransform>();
        maximizeSize = new Vector2(IntroRect.rect.width, introText.preferredHeight);
        minimizeSize = new Vector2(IntroRect.rect.width, 0);
        maximizeSize_2 = new Vector2(ContactRect_mask.rect.width, ContactRect_mask.rect.height);
        minimizeSize_2 = new Vector2(ContactRect_mask.rect.width, 0);
    }

    void Update()
    {
        Debug.Log(alreadyExpand_aboutMe);
    }

    public void ExpandAboutMe()
    {
        if (alreadyExpand_contact)
        {
            ExpandContact();
        }

        alreadyExpand_aboutMe = !alreadyExpand_aboutMe;

        if(alreadyExpand_aboutMe)
        {
            IntroRect.sizeDelta = maximizeSize;
            ContactRect_anchor.sizeDelta = maximizeSize;
            introButton.interactable = true;
        }
        else
        {
            IntroRect.sizeDelta = minimizeSize;
            ContactRect_anchor.sizeDelta = minimizeSize;
            introButton.interactable = false;
        }
    }

    public void ExpandContact()
    {
        if (alreadyExpand_aboutMe)
        {
            ExpandAboutMe();
        }

        alreadyExpand_contact = !alreadyExpand_contact;

        if (alreadyExpand_contact)
        {
            ContactRect_mask.sizeDelta = maximizeSize_2;
        }
        else
        {
            ContactRect_mask.sizeDelta = minimizeSize_2;
        }
    }
}
