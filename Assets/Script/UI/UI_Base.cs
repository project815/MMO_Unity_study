using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public abstract class UI_Base : MonoBehaviour
{
    private Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, Object[]>();

    public abstract void Init();
    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object [names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(GameObject) == typeof(T))
            {
                objects[i] = Util.FindChild(gameObject, names[i], true); // GameObject 찾기
            }
            else
            {
                objects[i] = Util.FindChild<T>(gameObject, names[i], true); // Component 찾기
            }

            if (objects[i] == null)
            {
                Debug.Log($"Failed to find {names[i]}");
            }
        }
    }

    protected  T Get<T>(int ids) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false) return null;
        return objects[ids] as T;
    }

    protected GameObject GetObject(int idx) {  return Get<GameObject>(idx);}
    protected  Text GetText(int idx) {return Get<Text>(idx);}
    
    protected  Image GetImage(int idx) {return Get<Image>(idx);}

    protected  Button GetButton(int idx) {return Get<Button>(idx);}
}
