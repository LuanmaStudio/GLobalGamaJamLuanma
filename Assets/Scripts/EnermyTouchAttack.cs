using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyTouchAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            if (other.contacts[0].point.y > other.transform.position.y)
            {
                print(other.contacts[0].point);
                print(other.transform.position);
                other.gameObject.GetComponent<HPBase>().TakeDamage(1,DamageType.Touch);
            }
        }
    }
}
