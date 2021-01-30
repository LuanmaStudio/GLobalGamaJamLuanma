using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PLayerAperance : MonoSingelton<PLayerAperance>
{
    private Material material;

    private void Awake()
    {
        Instance = this;
        
    }

    void Start()
    {
        material = GetComponent<SpriteRenderer>().sharedMaterial;
        material.SetFloat("_PixelateSize", 512);
    }

    public void Pixel(int target)
    {
        DOTween.To(() => material.GetFloat("_PixelateSize"), 
            i => material.SetFloat("_PixelateSize", i), target,1);
    }
    
}
