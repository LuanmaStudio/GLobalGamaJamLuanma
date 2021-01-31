using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public static int index = 1;
    
    public void Load()
    {
        
        SceneManager.LoadScene(index);
        index++;
    }
}
