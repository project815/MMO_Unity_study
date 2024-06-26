using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Inven : UI_Scene
{

    enum GameObjects
    {
        GridPanel
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        if(gridPanel.transform !=null)
        foreach (Transform child in gridPanel.transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }

        for (int i = 0; i < 8; i++)
        {
            Managers.UI.MakeSubItem<UI_Inven_Item>(gridPanel.transform).SetInfo("집행검");
        }
    }
}
