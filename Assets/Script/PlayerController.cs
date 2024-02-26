using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// 게임에서 사용되는 벡터
// 1. 위치 벡터
// 2. 방향 벡터 
struct MyVector
{
    public float x;
    public float y;
    public float z;

    public MyVector(float _x, float _y, float _z)
    {
        this.x = _x;
        this.y = _y;
        this.z = _z;
    }

    public float magnitude { get { return Mathf.Sqrt(x * x + y * y + z * z); } }
    public MyVector nomalized { get { return new MyVector(x / magnitude, y / magnitude, z / magnitude); } }

    public static MyVector operator +(MyVector a, MyVector b)
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);
    }
    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);
    }
}

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    void Start()
    {
        // 위치 벡터
        MyVector to = new MyVector(10.0f, 0.0f, 0.0f);
        MyVector from = new MyVector(5.0f, 0.0f, 0.0f);
        // 방향 벡터
        MyVector dir = to - from; // 5.0f, 0.0f, 0.0f

        // 방향 벡터
        //  1. 거리(크기) : 5     ; magnitude
        //  2. 실제 방향 : ->     ; normalized

    }

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

        // transform.position.magnitude; // 크기
        // transform.position.normalized; // 방향

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
