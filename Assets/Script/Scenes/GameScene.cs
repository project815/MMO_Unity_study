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

       co = StartCoroutine("AfterSeconds", 4.0f);
       StartCoroutine("StopSeconds", 2.0f);
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


    IEnumerator AfterSeconds(float seconds)
    {
        Debug.Log("Enter");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Exit");
    }

    IEnumerator StopSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if(co != null)
        {
            StopCoroutine(co);
            co = null;
            Debug.Log("Stop");

        }
    }
}
