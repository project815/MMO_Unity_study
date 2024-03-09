using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Define.CameraMode _mode = Define.CameraMode.QuarterView;
    [SerializeField]
    private Vector3 _delta = new Vector3(0.0f, 5.0f, -5.0f);
    [SerializeField]
    private GameObject player = null;
    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            transform.position = player.transform.position + _delta;
            transform.LookAt(player.transform);
                        
        }
    }
    
}
