using System.Collections;
using System.Collections.Generic;
using ECM.Examples;
using UnityEngine;

public class PlayerHp : HPBase
{

    public bool isImmunte = false;

    private Animator _animator;
    protected override void Start()
    {
        base.Start();
        _animator = GetComponentInChildren<Animator>();
        
    }
    
    
   

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int damage,DamageType type)
    {
        if (!isImmunte || type == DamageType.World)
        {
            base.TakeDamage(damage,type);
            _animator.SetTrigger("Hurt");
            EventCenter.Instance.EventTrigger("PlayerHit");
        }
            
    }

    public virtual void Healing(int value)
    {
        currentHp += value;

        currentHp = Mathf.Clamp(currentHp, 0, MaxHp);
        
        EventCenter.Instance.EventTrigger("PlayerHeal");
    }
    

    protected override void Death()
    {
        base.Death();
        _animator.SetBool("Dead",true);
        GetComponent<CharacterController2D>().enabled = false;

    }
}
