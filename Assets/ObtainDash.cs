using System;
using System.Collections;
using System.Collections.Generic;
using ECM.Examples;
using UnityEngine;

public class ObtainDash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController2D.CanDash = true;
            other.GetComponent<PlayerHp>().Healing(1);
            Destroy(gameObject);
        }
    }
}
