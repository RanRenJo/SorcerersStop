using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private RectTransform dragRectTransform;

    /*public void OndDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta;
    }*/

    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta/2;
    }
}
