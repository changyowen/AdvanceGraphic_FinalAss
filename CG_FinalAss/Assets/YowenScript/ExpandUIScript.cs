using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ExpandUIScript : MonoBehaviour
{
    public GameObject ShortIntroduction;
    public Button introButton;
    public Text introText;
    public GameObject ContactAnchorPoint;
    public GameObject ContactMaskContent;
    public Button expandIntroButton, expandContactButton;
    public Image expandIntroButton_img, expandContactButton_img;
    public Sprite maxi_sprite, mini_sprite;

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
        expandIntroButton_img = expandIntroButton.transform.gameObject.GetComponent<Image>();
        expandContactButton_img = expandContactButton.transform.gameObject.GetComponent<Image>();

        ExpandAboutMe_instant();
        ExpandAboutMe_instant();
        ExpandContact_instant();
        ExpandContact_instant();
    }

    public void ExpandAboutMe()
    {
        RedefineTextSize();

        if (alreadyExpand_contact)
        {
            ExpandContact();
        }

        alreadyExpand_aboutMe = !alreadyExpand_aboutMe;

        if(alreadyExpand_aboutMe)
        {
            expandIntroButton.interactable = false;
            StartCoroutine(changeSize(0, maximizeSize, IntroRect, true, true));
            StartCoroutine(changeSize(0, maximizeSize, ContactRect_anchor, true, true));
        }
        else
        {
            expandIntroButton.interactable = false;
            StartCoroutine(changeSize(0, minimizeSize, IntroRect, false, false));
            StartCoroutine(changeSize(0, minimizeSize, ContactRect_anchor, false, false));
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
            expandContactButton.interactable = false;
            StartCoroutine(changeSize(1, maximizeSize_2, ContactRect_mask, true, true));
        }
        else
        {
            expandContactButton.interactable = false;
            StartCoroutine(changeSize(1, minimizeSize_2, ContactRect_mask, true, false));
        }
    }

    IEnumerator changeSize(int index, Vector2 size, RectTransform rect, bool interactable, bool magnifying)
    {
        switch (index)
        {
            case 0:
                {
                    if (magnifying == true)
                    {
                        while (rect.sizeDelta.y < size.y)
                        {
                            rect.sizeDelta += new Vector2( 0, 160 * Time.deltaTime);
                            //change button tag to minimize
                            expandIntroButton.transform.gameObject.tag = "minimize";
                            yield return null;
                        }
                        expandIntroButton_img.sprite = mini_sprite;
                        introButton.interactable = interactable;
                    }
                    else
                    {
                        while (rect.sizeDelta.y > size.y)
                        {
                            rect.sizeDelta -= new Vector2( 0, 160 * Time.deltaTime);
                            //change button tag to minimize
                            expandIntroButton.transform.gameObject.tag = "maximize";
                            yield return null;
                        }
                        expandIntroButton_img.sprite = maxi_sprite;
                        introButton.interactable = interactable;
                    }
                    expandIntroButton.interactable = true;
                    break;
                }
            case 1:
                {
                    if (magnifying == true)
                    {
                        while (rect.sizeDelta.y < size.y)
                        {
                            rect.sizeDelta += new Vector2(0, 500 * Time.deltaTime);
                            //change button tag to minimize
                            expandContactButton.transform.gameObject.tag = "minimize";
                            yield return null;
                        }
                        expandContactButton_img.sprite = mini_sprite;
                    }
                    else
                    {
                        while (rect.sizeDelta.y > size.y)
                        {
                            rect.sizeDelta -= new Vector2(0, 500 * Time.deltaTime);
                            //change button tag to minimize
                            expandContactButton.transform.gameObject.tag = "maximize";
                            yield return null;
                        }
                        expandContactButton_img.sprite = maxi_sprite;
                    }
                    expandContactButton.interactable = true;
                    break;
                }
        }
    }

    public void ExpandAboutMe_instant()
    {
        RedefineTextSize();

        if (alreadyExpand_contact)
        {
            ExpandContact_instant();
        }

        alreadyExpand_aboutMe = !alreadyExpand_aboutMe;

        if (alreadyExpand_aboutMe)
        {
            IntroRect.sizeDelta = maximizeSize;
            ContactRect_anchor.sizeDelta = maximizeSize;
            introButton.interactable = true;
            expandIntroButton_img.sprite = mini_sprite;
            //change button tag to minimize
            expandIntroButton.transform.gameObject.tag = "minimize";
        }
        else
        {
            IntroRect.sizeDelta = minimizeSize;
            ContactRect_anchor.sizeDelta = minimizeSize;
            introButton.interactable = false;
            expandIntroButton_img.sprite = maxi_sprite;
            //change button tag to minimize
            expandIntroButton.transform.gameObject.tag = "maximize";
        }
    }

    public void ExpandContact_instant()
    {
        if (alreadyExpand_aboutMe)
        {
            ExpandAboutMe_instant();
        }

        alreadyExpand_contact = !alreadyExpand_contact;

        if (alreadyExpand_contact)
        {
            ContactRect_mask.sizeDelta = maximizeSize_2;
            expandContactButton_img.sprite = mini_sprite;
            //change button tag to minimize
            expandContactButton.transform.gameObject.tag = "minimize";
        }
        else
        {
            ContactRect_mask.sizeDelta = minimizeSize_2;
            expandContactButton_img.sprite = maxi_sprite;
            //change button tag to minimize
            expandContactButton.transform.gameObject.tag = "maximize";
        }
    }

    void RedefineTextSize()
    {
        maximizeSize = new Vector2(IntroRect.rect.width, introText.preferredHeight);
        minimizeSize = new Vector2(IntroRect.rect.width, 0);
    }
}
