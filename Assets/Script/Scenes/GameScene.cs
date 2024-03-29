using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
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
        Debug.Log("GameScene Clear!");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Managers.Scene.LoadeScene(Define.Scene.Login);
        }
    }
}
