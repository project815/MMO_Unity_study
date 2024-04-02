using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private Coroutine co;
    void Awake()
    {
        Init();

        
    }
    
    public override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;
        
        Managers.UI.ShowSceneUI<UI_Inven>();

    }
    
    public override void Clear()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Managers.Scene.LoadeScene(Define.Scene.Login);
        }
    }
}
