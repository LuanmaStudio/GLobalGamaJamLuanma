using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyHP : HPBase, IRestart
{
    void Start()
    {
        ReloadManager.Instance.List.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Death()
    {
        Destroy(Instantiate(Resources.Load<GameObject>("Blood"), transform.position, Quaternion.Euler(90,0,0)),3f);
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        currentHp = maxHp;
        gameObject.SetActive(true);
    }
}
