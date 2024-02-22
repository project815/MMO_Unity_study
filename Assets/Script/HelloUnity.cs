using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloUnity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HelloUnity");
    }

    // Update is called once per frame
    void Update()
    {
        // Conponent 패턴
        // 애니메이션 갱신
        //  _anim.Update(delataTick);
        //
        // 스킬 쿨타임을 체크해서 스킬 날린다.
        // _skill.Update(deltaTick);
        //
        // 물리 적용(중력 등)
        // _physics.Update(detaTick);
    }

    // AnimationComponent _anim = new AnimationComponent();
    // SkillComponent _skill = new SkillComponent();
    // PhysicsComponent _physics = new PhysicsComponent();
}


// 언리얼의 경우 컴포넌트 + 상속, 유니티 컴포넌트


//
//
