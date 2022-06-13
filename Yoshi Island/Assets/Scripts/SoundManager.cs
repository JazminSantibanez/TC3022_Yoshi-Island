using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Protected variables (private but appear in the editor) 
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;

    private bool muted = false;


    // Start is called before the first frame update
    /* 
        Searches for the muted variable stored in the preferences.
        If not found, it will be set to false.
        Updates the icon according to the state of the muted variable.
        Matches the pause of the music to the muted value.
    */
    void Start()
    {
        if( !PlayerPrefs.HasKey("muted") )
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    /* 
        Function called when the button is clicked.
        It flips the state of the music
        and the value of the mute variable.
        Finally, calls the save and Update icon functions.
    */
    public void OnButtonPress()
    {
       
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButtonIcon();
    }

    /*
        Function that flips the image of the icon based on the muted variable.
    */
    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    /*
        Function that loads the value of the muted
        variable from the preferences.
    */
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    /*
        Function that saves the muted variable in the preferences.
    */
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

}
