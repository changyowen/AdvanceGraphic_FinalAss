using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private static Tooltip instance;

    public GameObject background, text;

    private Text tooltipText;
    private RectTransform backgroundRectTransform;
    private RectTransform CanvasRectTransform;
    private RectTransform TooltipRect;

    private void Awake()
    {
        instance = this;
        backgroundRectTransform = background.GetComponent<RectTransform>();
        CanvasRectTransform = transform.parent.GetComponent<RectTransform>();
        TooltipRect = GetComponent<RectTransform>();
        tooltipText = text.GetComponent<Text>();

        HideTooltip_static();
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(CanvasRectTransform, Input.mousePosition, null, out localPoint);
        transform.localPosition = localPoint;

        Vector2 anchoredPosition = TooltipRect.anchoredPosition;
        if ((anchoredPosition.x + backgroundRectTransform.rect.width) > CanvasRectTransform.rect.width / 2)
        {
            anchoredPosition.x = CanvasRectTransform.rect.width / 2 - backgroundRectTransform.rect.width;
        }
        if ((anchoredPosition.y + backgroundRectTransform.rect.height) > CanvasRectTransform.rect.height / 2)
        {
            anchoredPosition.y = CanvasRectTransform.rect.height / 2 - backgroundRectTransform.rect.height;
        }
        TooltipRect.anchoredPosition = anchoredPosition;
    }

    private void ShowTootip(string tooltipString)
    {
        gameObject.SetActive(true);
        TooltipRect.SetAsLastSibling();
        tooltipText.text = tooltipString;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth + textPaddingSize * 2, tooltipText.preferredHeight + textPaddingSize * 2);
        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public static void ShowTooltip_static(string tooltipString)
    {
        instance.ShowTootip(tooltipString);
    }

    public static void HideTooltip_static()
    {
        instance.HideTooltip();
    }
}
