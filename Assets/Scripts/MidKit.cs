using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidKit : MonoBehaviour , IRestart
{
    private void Start()
    {
        ReloadManager.Instance.List.Add(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHp>().Healing(1);
            gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        gameObject.SetActive(true);
    }
}
