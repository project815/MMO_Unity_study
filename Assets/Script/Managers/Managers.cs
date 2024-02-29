using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성을 보장한다. (static으로 선언함으로써 그 특성상)
    public static Managers Instance { get { init(); return s_instance; } }// 유일한 매니저를 갖고 온다., 프로퍼티로 선언, 함수 선언된 표현식을 개선.

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();

    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    void Start()
    {
        // 1. 하이라키 내에 유일성을 확보하자!
        // instance = this; // 하이라키 내에 여러 개의 Managers 컴포넌트가 존재할 경우, 가장 마지막에 생성된 Managers 컴포넌트까지 계속 덮어쓴다.

        // GameObject go = GameObject.Find("@Managers"); // 유일성을 확보하기 위해 특정 오브젝트 안에 Managers를 instance로 만든다.
        // instance = go.GetComponent<Managers>();

        // 2. 만약 하이라키 내에 Managers가 존재하지 않는다면?? Managers를 찾을 수 없다면 다른 스크립트에서 GetInstance()를 호출할 때, NullReferenceException이 발생한다.
        //init();

        init();
    }

    void Update()
    {
        _input.OnUpdate();
    }
    static void init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null) // 하이라키 내에 @Managers가 없으면 생성한다.
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>(); // 유일한 Managers를 갖고 온다.
        }
    }
}
