using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : HPBase
{

    public bool isImmunte = false;

    private Animator _animator;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int damage,DamageType type)
    {
        if(!isImmunte)
            base.TakeDamage(damage,type);
    }
    

    protected override void Death()
    {
        base.Death();
        _animator.SetBool("Dead",true);
    }
}
