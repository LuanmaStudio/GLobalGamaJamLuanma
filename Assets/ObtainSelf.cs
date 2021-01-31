using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainSelf : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PLayerAperance.Instance.Pixel(256);
            other.gameObject.GetComponent<PlayerHp>().Healing(0);
            Destroy(gameObject);
        }
    }
}
