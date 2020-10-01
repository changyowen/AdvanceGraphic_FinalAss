using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipAssign : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public EmptyText ET;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.ShowTooltip_static(ET.GuideText);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideTooltip_static();
    }

    public void HideTooltipManual()
    {
        Tooltip.HideTooltip_static();
    }
}
