using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    bool invertCheckboxOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        // return to the previous scene
        if (PlayerPrefs.HasKey("lastScene"))
        {
            int lastScene = PlayerPrefs.GetInt("lastScene");
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void ToggleYInvert()
    {
        if (invertCheckboxOn == true)
        {
            invertCheckboxOn = false;
        }
        else
        {
            invertCheckboxOn = true;
        }
    }

    public void Apply()
    {
        // Use PlayerPrefs to save settings changes
        // if inverted, turn off ; if regular, invert
        if (PlayerPrefs.GetInt("YInvert") == 1 && invertCheckboxOn == false)
        {
            PlayerPrefs.SetInt("YInvert", 0);
        }
        else if (PlayerPrefs.GetInt("YInvert") == 0 && invertCheckboxOn == true)
        {
            PlayerPrefs.SetInt("YInvert", 1);
        }

        Back();
    }
}