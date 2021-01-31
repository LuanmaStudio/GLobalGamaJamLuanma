using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyWalk : MonoBehaviour
{
    public float Speed = 0.1f;
    
    private Rigidbody _rigidbody;
    private Vector2 dir;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        dir = Vector2.left;
    }

    
    void FixedUpdate()
    {
        Ray ray = new Ray(transform.GetChild(0).position, Vector3.down);
        if (Physics.Raycast(ray, 3)&& Physics.OverlapBox(transform.GetChild(0).position,Vector3.one*0.1f,Quaternion.identity).Length==0)
        {
            _rigidbody.velocity = (Vector3)dir * Speed;
            _rigidbody.velocity += Vector3.down * 9;
        }
        else
        {
            dir = -dir;
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
    }
}
