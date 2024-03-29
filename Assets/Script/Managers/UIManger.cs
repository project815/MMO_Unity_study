using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class UIManger
{
    private int _order = 10;

    private Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    private UI_Scene _uiScene = null;

    private GameObject _Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null) // 하이라키 내에 @Managers가 없으면 생성한다.
            {
                root = new GameObject { name = "@UI_Root" };
            }
            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.overrideSorting = true; 
        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        T scene = Util.GetOrAddComponent<T>(go);
        _uiScene = scene;
        
        go.transform.SetParent(_Root.transform);

        return scene;
    }
    public T ShowPopupUI<T>(string name = null)where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);
        
        go.transform.SetParent(_Root.transform);

        return popup;
    }

    public T MakeSubItem<T>(Transform parent, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/SubItem/{name}");
        if (parent != null)
            go.transform.SetParent(parent);
        
        return Util.GetOrAddComponent<T>(go);;
    }

    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0)
            return;
        if (_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed");
            return;
        }
        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
        {
            return;
        }

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;
    }

    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
        {
            ClosePopupUI();
        }
    }
}
