using System;
using System.Collections;
using System.Collections.Generic;
using ECM.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : HPBase , IRestart
{

    public bool isImmunte = false;

    private Animator _animator;

    public static PlayerHp Instance;

    private void Awake()
    {
        Instance = this;
    }

    protected override void Start()
    {
        base.Start();
        _animator = GetComponentInChildren<Animator>();
        ReloadManager.Instance.List.Add(this);
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

        currentHp = Mathf.Clamp(currentHp, 0, MAXHp);
        
        EventCenter.Instance.EventTrigger("PlayerHeal");
    }
    

    protected override void Death()
    {
        base.Death();
        _animator.SetBool("Dead",true);
        GetComponent<CharacterController2D>().movement.velocity = Vector3.down*10;
        GetComponent<CharacterController2D>().enabled = false;
        global::Restart.Instance.gameObject.SetActive(true);
        EventCenter.Instance.EventTrigger("PlayerDead");
    }

    public void Reset()
    {
        GetComponent<CharacterController2D>().enabled = true;
        currentHp = maxHp;
        _animator.SetBool("Dead",false);
        _animator.Play("Idle");
        transform.position = GameObject.Find("SpawnPoint").transform.position;
    }
}
