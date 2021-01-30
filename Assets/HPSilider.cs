using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSilider : MonoBehaviour
{
    private Slider _silider;
    void Start()
    {
        _silider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        _silider.value = (float)PlayerHp.Instance.CurrentHp / PlayerHp.Instance.MAXHp;
    }
}
