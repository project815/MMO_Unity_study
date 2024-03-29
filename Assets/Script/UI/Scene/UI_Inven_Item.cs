using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inven_Item : UI_Base
{
    enum GameObjecs
    {
        ItemIcon,
        ItemNameText,
    }

    private string _name;
    

    public void Start()
    { 
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjecs));
        Get<GameObject>((int)GameObjecs.ItemNameText).GetComponent<Text>().text = _name;

        Get<GameObject>((int)GameObjecs.ItemIcon).AddUIEvent((PointerEventData)=>{Debug.Log($"아이템 클릭 : {_name}");});
    }

    public void SetInfo(string name)
    {
        _name = name;
    }
}
