using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Managers
{
    public class SceneManagerEx
    {
        public BaseScene CurrentScene { get {return GameObject.FindObjectOfType<BaseScene>();} }
        
        public void LoadeScene(Define.Scene type)
        {
            global::Managers.Clear();
            CurrentScene.Clear();
            SceneManager.LoadScene(GetSceneName(type));
        }

        string GetSceneName(Define.Scene type)
        {
            string name = System.Enum.GetName(typeof(Define.Scene), type);
            return name;
        }

        public void Clear()
        {
            CurrentScene.Clear();
        }
    }
}