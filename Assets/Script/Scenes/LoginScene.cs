using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScene : BaseScene
{
    void Awake()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Login;
    }

    public override void Clear()
    {
        Debug.Log("LoginScene Clear!");
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Managers.Scene.LoadeScene(Define.Scene.Game);
        }
    }
}
