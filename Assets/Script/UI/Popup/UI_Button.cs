using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UI_Button : UI_Popup
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
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons)); //reflection ????? c# ?? 
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));

        Bind<GameObject>(typeof(GameObjects));
        GetText((int)Texts.ScoreText).text = "Buinding Text";
        GameObject go = GetImage((int)Images.TestImage).gameObject;
        Action<PointerEventData> action = (PointerEventData data) => { go.transform.position = data.position; };
        UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);
        switch (Define.UIEvent.Drag)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                evt.OnDragHandler -= action;
                evt.OnDragHandler += action;
                break;
        }

        GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);
    }
    
    public void OnButtonClicked(PointerEventData data)
    {
        score++;
        GetText((int)Texts.ScoreText).text =$"점수 : {score}";
    }
}
