using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    //Creation of variable to store the music file
    private static BackgroundMusic backgroundMusic;

    /*
        Function that is executed at the execution.
        If an object of type BackgroundMusic is detected, it will be destroyed.
        If there is no object, it will be created.
    */
    void Awake()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }
        else
        {
            Destroy(backgroundMusic);
        }
    }
}
