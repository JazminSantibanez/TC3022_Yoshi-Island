using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    //Creation of variable to store the music file
    private static BackgroundMusic backgroundMusic;

    /*
        Funcion a ejecutar al inicio.
        Si detecta un objeto de tipo BackgroundMusic, lo destruye.
        Si no, crea uno.
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
