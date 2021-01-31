using System;
using System.Collections;
using System.Collections.Generic;
using ECM.Examples;
using UnityEngine;

public class ObtainDoubleJump : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterController2D>().maxMidAirJumps = 1;
            other.GetComponent<PlayerHp>().Healing(1);
            Destroy(gameObject);
        }
    }
}
