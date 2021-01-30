using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFmodScript : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string walkSound;

    [FMODUnity.EventRef]
    public string hitSound;

    [FMODUnity.EventRef]
    public string dashSound;

    [FMODUnity.EventRef]
    public string jumpSound;

    [FMODUnity.EventRef]
    public string healSound;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.Instance.AddEventListener("PlayerJump", jumpsound);
        EventCenter.Instance.AddEventListener("PlayerHit", hitsound);
        EventCenter.Instance.AddEventListener("PlayerHeal", healsound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void walksound()
    {
        FMOD.Studio.EventInstance walk = FMODUnity.RuntimeManager.CreateInstance(walkSound);
        walk.start();
    }

    public void hitsound()
    {
        FMOD.Studio.EventInstance walk = FMODUnity.RuntimeManager.CreateInstance(hitSound);
        walk.start();
    }

    public void dashsound()
    {
        FMOD.Studio.EventInstance walk = FMODUnity.RuntimeManager.CreateInstance(dashSound);
        walk.start();
    }

    public void healsound()
    {
        FMOD.Studio.EventInstance walk = FMODUnity.RuntimeManager.CreateInstance(healSound);
        walk.start();
    }

    public void jumpsound()
    {
        FMOD.Studio.EventInstance walk = FMODUnity.RuntimeManager.CreateInstance(jumpSound);
        walk.start();
    }

}
