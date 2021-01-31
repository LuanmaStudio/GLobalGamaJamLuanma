using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = target.position;
        }
    }

    public void Teleprot()
    {
        GameObject.FindWithTag("Player").transform.position = target.position;
        transform.parent.gameObject.SetActive(false);
    }
}
