using System;
using System.Collections;
using System.Collections.Generic;
using ECM.Components;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerHp _playerHp;
    private CharacterMovement _movement;
    private CapsuleCollider capsuleCollider;
    [FMODUnity.EventRef]
    public string dashSound;
    
    void Start()
    {
        EventCenter.Instance.AddEventListener("PlayerAttack",BeginAttack);
        _playerHp = GetComponentInParent<PlayerHp>();
        _movement = GetComponentInParent<CharacterMovement>();
        capsuleCollider = GetComponentInParent<CapsuleCollider>();
    }

    private void FixedUpdate()
    {
        if (_movement.isGrounded == false && _movement.velocity.y < 0)
        {
            var collider = Physics.OverlapBox(capsuleCollider.bounds.center
                , Vector3.one, Quaternion.identity);
            foreach (var item in collider)
            {
                if (item.CompareTag("Enermy"))
                {
                    item.GetComponent<HPBase>().TakeDamage(1,DamageType.Kick);
                }
            }
            return;
        }
        
    }

    IEnumerator Inmmute(float time)
    {
        _playerHp.isImmunte = true;
        yield return new WaitForSeconds(time);
        _playerHp.isImmunte = false;
    }

    void BeginAttack()
    {
        FMODUnity.RuntimeManager.PlayOneShot(dashSound, transform.position);
        StartCoroutine(Attack());
        print("Attack");
    }

    IEnumerator Attack()
    {
        float dashTimeLeft = 0.15f;

        while (true)
        {
            var collider = Physics.OverlapBox(transform.position, Vector3.one*2, Quaternion.identity);
            _playerHp.isImmunte = true;
            foreach (var item in collider)
            {
                if (item.CompareTag("Enermy"))
                {
                    item.GetComponent<HPBase>().TakeDamage(1,DamageType.Dash);
                }
            }
            dashTimeLeft -= 0.02f;

            if (dashTimeLeft < 0)
            {
                dashTimeLeft = 0.3f;
                _playerHp.isImmunte = false;
                break;
            }
            yield return new WaitForSeconds(0.05f);
                
                
        }
    }
    
}
