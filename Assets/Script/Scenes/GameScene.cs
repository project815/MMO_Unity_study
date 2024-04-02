using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Inven>();
        Dictionary<int, Stat> dict = Managers.Data.StatDict;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            Init();
        }
    }

    public override void Clear()
    {
    }
}
