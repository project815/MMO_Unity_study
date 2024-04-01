using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        if (typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index= name.LastIndexOf("/");
            if (index >= 0) name = name.Substring(index + 1);

            GameObject go = Managers.Pool.GetOriginal(name);
            
            if(go != null)
                return go as T;
        }
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        //1. 오리지널이 이미 있으면 바로 사용하기
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Failed to load prefab: {path}");
            return null;
        }

        //2. 복사본을 계속 만드는 게 아닌 풀링된 오브젝트를 찾아서 사용
        if (original.GetComponent<Poolable>() != null)
        {
            return Managers.Pool.Pop(original, parent).gameObject;
        }
        GameObject go = Object.Instantiate(original, parent);
        int index = go.name.IndexOf("(Clone)");
        if (index > 0)
            go.name = go.name.Substring(0, index);

        return go;

        return go;
    }

    public void Destroy(GameObject go, float delta = 0)
    {
        if (go == null) return;

        // 바로 제거가 아닌 풀링이 필요한 오브젝트면 풀링 매니저에게 위탁.
        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }
        Object.Destroy(go, delta);
    }
}
