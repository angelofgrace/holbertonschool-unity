using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public Toggle yInvert;

    // Start is called before the first frame update
    void Start()
    {
    //    PlayerPrefs.SetInt("navFromOptions", 1);
        if (PlayerPrefs.GetInt("YInvert") == 1)
        {
            yInvert.isOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        PlayerPrefs.SetInt("navFromOptions", 1);
        
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

    public void Apply()
    {
        PlayerPrefs.SetInt("navFromOptions", 1);

        // Use PlayerPrefs to save settings changes
        // if inverted, turn off ; if regular, invert
        if (yInvert.isOn == false)
        {
            PlayerPrefs.SetInt("YInvert", 0);
        }
        else if (yInvert.isOn == true)
        {
            PlayerPrefs.SetInt("YInvert", 1);
        }

        Back();
    }
}