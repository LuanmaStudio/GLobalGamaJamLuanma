
using System;
using UnityEngine;

public class HPBase : MonoBehaviour
{
    public int MaxHp = 1;

    [SerializeField]private int currentHp;

    protected virtual void Start()
    {
        currentHp = MaxHp;
    }


    protected virtual void Death()
    {
        print(this.name+" Dead!");
    }

    public virtual void TakeDamage(int damage,DamageType type)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Death();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone"))
        {
            Death();
        }
    }
}