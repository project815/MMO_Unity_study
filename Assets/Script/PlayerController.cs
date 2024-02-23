using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.W))
        //     transform.position += new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * _speed;
        // if (Input.GetKey(KeyCode.S))
        //     transform.position -= new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * _speed;
        // if (Input.GetKey(KeyCode.A))
        //     transform.position -= new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime * _speed;
        // if (Input.GetKey(KeyCode.D))
        //     transform.position += new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime * _speed;


        // 월드 좌표 기반으로 이동
        // if (Input.GetKey(KeyCode.W))
        //     transform.position += Vector3.forward * Time.deltaTime * _speed;
        // if (Input.GetKey(KeyCode.S))
        //     transform.position += Vector3.back * Time.deltaTime * _speed;
        // if (Input.GetKey(KeyCode.A))
        //     transform.position += Vector3.left * Time.deltaTime * _speed;
        // if (Input.GetKey(KeyCode.D))
        //     transform.position += Vector3.right * Time.deltaTime * _speed;

        // TransformDirection : Local -> World
        // InverseTransformDirection : World -> Local
        // if (Input.GetKey(KeyCode.W))
        //     transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        // if (Input.GetKey(KeyCode.S))
        //     transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * _speed);
        // if (Input.GetKey(KeyCode.A))
        //     transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * _speed);
        // if (Input.GetKey(KeyCode.D))
        //     transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * _speed);


        // transform.Translate
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * _speed);

    }
}
