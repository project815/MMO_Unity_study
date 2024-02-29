using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    // public GameObject Prefab;
    void Start()
    {

        // GameObject Prefab = Resources.Load<GameObject>("Prefabs/Tank");
        // GameObject tank = Instantiate(Prefab);
        // Destroy(tank, 3.0f);

        GameObject tank = Managers.Resource.Instantiate("Tank");
        Managers.Resource.Destroy(tank, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
