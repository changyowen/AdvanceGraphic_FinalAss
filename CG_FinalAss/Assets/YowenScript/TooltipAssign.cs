using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipAssign : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public EmptyText ET;
    public EmptyText ET_2;

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch(this.tag)
        {
            case "minimize":
                {
                    Tooltip.ShowTooltip_static(ET_2.GuideText);
                    break;
                }
            default:
                {
                    Tooltip.ShowTooltip_static(ET.GuideText);
                    break;
                }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideTooltip_static();
    }

    public void HideTooltipManual()
    {
        Tooltip.HideTooltip_static();
    }

    public void OpenTooltipManual()
    {
        switch (this.tag)
        {
            case "minimize":
                {
                    Tooltip.ShowTooltip_static(ET_2.GuideText);
                    break;
                }
            default:
                {
                    Tooltip.ShowTooltip_static(ET.GuideText);
                    break;
                }
        }
    }

    public void RefreshTooptipManual()
    {
        Tooltip.HideTooltip_static();
        OpenTooltipManual();
    }
}
