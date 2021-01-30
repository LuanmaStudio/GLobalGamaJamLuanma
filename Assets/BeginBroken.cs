using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginBroken : MonoBehaviour
{
    public BoxCollider2D Collider;
    public TextAsset TextAsset;

    private bool trigged = false;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")&& !trigged)
        {
            PLayerAperance.Instance.Pixel(17);
            Destroy(Collider);
            Dialog.instance.ShowDialog(TextAsset);
            EventCenter.Instance.EventTrigger("BeginBroken");
            trigged = true;
        }
    }
}
