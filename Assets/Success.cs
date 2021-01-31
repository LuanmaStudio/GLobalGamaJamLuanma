using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Success : MonoBehaviour
{

    public GameObject titile;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            titile.SetActive(true);
            other.GetComponent<PlayerHp>().TakeDamage(100,DamageType.System);
            Destroy(gameObject);
            
        }
    }
}
