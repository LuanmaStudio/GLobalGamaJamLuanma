using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyHP : HPBase
{
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Death()
    {
        Destroy(gameObject);
    }
}
