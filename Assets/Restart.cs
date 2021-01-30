using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoSingelton<Restart>, IRestart
{
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameObject.SetActive(false);
        ReloadManager.Instance.List.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadManager.Instance.Reset();
        }
    }

    public void Reset()
    {
        gameObject.SetActive(false);
    }
}
