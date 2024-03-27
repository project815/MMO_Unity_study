using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    public Action<PointerEventData> OnClickHandler = null;
    public Action<PointerEventData> OnDragHandler = null;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("움직임 시작");
        if (OnClickHandler != null)
        {
            OnClickHandler.Invoke(eventData);
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
