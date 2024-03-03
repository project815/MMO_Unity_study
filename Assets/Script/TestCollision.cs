using UnityEngine;

public class TestCollision : MonoBehaviour
{
  // 1. 나한테 rigidbody가 있어야 한다.(isKinematic : off)
  // 2. 나한테 collider가 있어야 한다. (isTrigger : off)
  // 3. 상대한테 collider가 있어야 한다. (isTrigger : off)
  
  private void OnCollisionEnter(Collision other)
  { 
    Debug.Log("onCollisionEnter");
  }

  private void OnTriggerEnter(Collider other)
  { 
    Debug.Log("OnTriggerEnter");
  }
}
