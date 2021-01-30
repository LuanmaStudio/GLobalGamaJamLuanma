using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidKit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHp>().Healing(1);
            Destroy(gameObject);
        }
    }
}
