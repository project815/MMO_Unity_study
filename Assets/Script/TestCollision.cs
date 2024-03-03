using UnityEngine;

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
}
