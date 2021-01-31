using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 dir;

    private Rigidbody _rigidbody;
    void Start()
    {
       _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = dir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHp>().TakeDamage(1,DamageType.Shoot);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Untagged"))
        {
            Destroy(gameObject);
        }
    }
}
