using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UI_Button : UI_Base
{
    [SerializeField] private Text _text;
    private int score = 0;


    enum Buttons
    {
        PointButton
    }
    enum Texts
    {
        PointText,
        ScoreText,
    }

    enum GameObjects
    {
        TestObject,
    }

    enum Images
    {
        TestImage,
    }

    private void Start()
    {
        Bind<Button>(typeof(Buttons)); //reflection ????? c# ?? 
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));

        Bind<GameObject>(typeof(GameObjects));

        GetText((int)Texts.ScoreText).text = "Buinding Text";
        
        GameObject go = GetImage((int)Images.TestImage).gameObject;
        UI_EventHandler evt = go.AddComponent<UI_EventHandler>();
        evt.OnDragHandler += (PointerEventData data) =>
        {
            Debug.Log($"data : {data}");
            evt.gameObject.transform.position = data.position;
        };

    }

  

    
    public void OnButtonClicked()
    {
        Debug.Log(">???");
        score++;
        _text.text = $"점수 : {score}";
    }
}
