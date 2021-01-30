
using System;
using UnityEngine;

public class HPBase : MonoBehaviour
{
    [SerializeField]public int maxHp = 1;

    [SerializeField]protected int currentHp;

    public int MAXHp
    {
        get => maxHp;
        private set => maxHp = value;
    }

    public int CurrentHp
    {
        get => currentHp;
        private set => currentHp = value;
    }

    protected virtual void Start()
    {
        currentHp = maxHp;
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