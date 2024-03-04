using System;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class TestCollision : MonoBehaviour
{
  // 1. 나한테 rigidbody가 있어야 한다.(isKinematic : off)
  // 2. 나한테 collider가 있어야 한다. (isTrigger : off)
  // 3. 상대한테 collider가 있어야 한다. (isTrigger : off)
  private void OnCollisionEnter(Collision other)
  {
    Debug.Log($"collision : {other.gameObject.name}");
  }
  
  // 1. 둘 다 collider가 있어야 한다.
  // 2. 둘 중 하나는 isTrigger : on
  // 3. 둘 중 하나는 Rigidbody가 있어야 한다.
  private void OnTriggerEnter(Collider other)
  { 
    Debug.Log("OnTriggerEnter");
  }

  private void Update()
  {
    // 로컬 좌표 전환
    Vector3 look = transform.TransformDirection(Vector3.forward);
    
    Debug.DrawRay(transform.position + Vector3.up, look * 100, Color.red);
    // RayCastHit 값
    RaycastHit hit;
    if(Physics.Raycast(transform.position + Vector3.up, look * 100, out hit))
    {
      //출력 이름
      Debug.Log($"RayCasting!~{hit.transform.gameObject.name}");
    }


    // RaycastHit[] hit = Physics.RaycastAll(transform.position + Vector3.up, look * 100);
    //
    // foreach(RaycastHit i in hit)
    // {
    //   Debug.Log(i.transform.gameObject.name);      
    // }

    
    // 사용 예시
    // 캐릭터와 카메라 사이에 다른 물체가 있다면, 카메라를 앞쪽으로 이동하도록 만들 수 있다.
  } 
}
