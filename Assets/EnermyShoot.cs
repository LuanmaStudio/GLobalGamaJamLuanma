using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyShoot : MonoBehaviour
{
    public float bulletSpeed = 5;
    public float shootInterval = 1f;
    private GameObject bullet;
    private Rigidbody _rigidbody;
    private float currentTime;
    
    void Start()
    {
        bullet = Resources.Load<GameObject>("Bullet");
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > currentTime)
        {
            var go = Instantiate(bullet, transform.position, Quaternion.identity);
            go.GetComponent<Bullet>().dir = _rigidbody.velocity.normalized * bulletSpeed;
            if (_rigidbody.velocity.x > 0) go.transform.localScale = new Vector3(-1, 1, 1);

            Destroy(go,3);
            
            currentTime = Time.time + shootInterval;
        }
        

    }
    
}
