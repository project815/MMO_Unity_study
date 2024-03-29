using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
    // public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component
    // {
    //     return go.GetOrAddComponent<T>();
    // }
    //
    public static void BindEvent(this GameObject go, Action<PointerEventData> action,
        Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);
        switch (type)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                evt.OnDragHandler -= action;
                evt.OnDragHandler += action;
                break;
        }
    }
    
}

