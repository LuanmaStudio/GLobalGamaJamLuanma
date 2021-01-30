
using System;
using UnityEngine;

public class MonoSingelton<T>: MonoBehaviour where T: Component 
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance != null) return instance;
            var go = new GameObject(typeof(T).Name);
            DontDestroyOnLoad(go);
            return instance = go.AddComponent<T>();
        }
        private set { instance = value; }
    }
}
