using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null;
    public Action <Define.MouseEvent> MouseAction = null;
    
    // Action : 델리게이트
    private bool _pressed = false;
    

    public void OnUpdate()
    {
        // if (Input.anyKey == false) return;
        // 어떤 키를 누르면 KeyAction이 호출된다. 
        // KeyAction에 함수를 담아주고, 클래스 안에 OnUpdate함수를 실행해주면 사용할 수 있다.
        // KeyAction은 PlayerController안에 키보드를 누르면 눌리는 함수를 넣어주면 된다.
        // OnUpdate는 Managers클래스 안에 Update이벤트 주기 함수에서 실행시킨다.

        // if (KeyAction != null)
        // {
        //     KeyAction.Invoke();
        // }
        
        if(Input.anyKey && KeyAction != null) KeyAction.Invoke();

        if (MouseAction != null)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press );
                _pressed = true;
                
            }
            else
            {
                if (_pressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                    _pressed = false;
                }
            }
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
