using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScene : BaseScene
{
    void Awake()
    {
        Init();
        List<GameObject> poolList = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            poolList.Add(Managers.Resource.Instantiate("Player/Player"));
        }

        foreach (GameObject go in poolList)
        {
            Managers.Resource.Destroy(go);
        }
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
