using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGetPrefferedHeight : MonoBehaviour
{
    Vector3 minimizeSize, maximizeSize;
    bool Max = false;
    RectTransform rectTransform;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        text = GetComponent<Text>();
        maximizeSize = new Vector2(rectTransform.rect.width, text.preferredHeight);
        minimizeSize = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
    }


    public void test()
    {
        Max = !Max;

        if(Max)
        {
            rectTransform.sizeDelta = maximizeSize;
        }
        else
        {
            rectTransform.sizeDelta = minimizeSize;
        }
    }
}
