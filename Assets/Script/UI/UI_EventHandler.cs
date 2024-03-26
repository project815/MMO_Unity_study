using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Action<PointerEventData> OnBeginDragHandler = null;
    public Action<PointerEventData> OnDragHandler = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("움직임 시작");
        if (OnBeginDragHandler != null)
        {
            OnBeginDragHandler.Invoke(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("움직임 진행 중.");
        if (OnDragHandler != null)
        {
            OnDragHandler.Invoke(eventData);
        }
    }

}
