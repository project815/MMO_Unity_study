using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Start()
    {
        Bind<Button>(typeof(Buttons)); //reflection ????? c# ?? 
        Bind<Text>(typeof(Texts));

        Bind<GameObject>(typeof(GameObjects));

        GetText((int)Texts.ScoreText).text = "Buinding Text";
    }

  

    
    public void OnButtonClicked()
    {
        Debug.Log(">???");
        score++;
        _text.text = $"점수 : {score}";
    }
}
