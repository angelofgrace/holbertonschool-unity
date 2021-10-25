using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    public AudioMixer mixer;

    void Start()
    {
        // Set current scene pref for navigation
        PlayerPrefs.DeleteKey("navFromOptions");
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);

        // Check for volume settings
        if (PlayerPrefs.HasKey("bgmVol"))
        {
            mixer.SetFloat("bgmVol", LinearToDecibel(PlayerPrefs.GetFloat("bmgVol")));
        }
        if (PlayerPrefs.HasKey("sfxVol"))
        {
            mixer.SetFloat("sfxVol", LinearToDecibel(PlayerPrefs.GetFloat("sfxVol")));
        }
    }

    public void LevelSelect(int level)
    {
        SceneManager.LoadScene("Level0" + level);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    private float LinearToDecibel(float linear)
    {
        float dB;

        if (linear != 0)
        {
            dB = 20.0f * Mathf.Log10(linear);
        }
        else
        {
            dB = -144.0f;
        }

        return dB;
    }
}
