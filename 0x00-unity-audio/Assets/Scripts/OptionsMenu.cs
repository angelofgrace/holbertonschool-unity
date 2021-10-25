using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    public Toggle yInvert;

    public Slider bgm;
    public static float bgmSlider = 1f;
    public Slider sfx;
    public static float sfxSlider = 1f;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
    //    PlayerPrefs.SetInt("navFromOptions", 1);
        if (PlayerPrefs.GetInt("YInvert") == 1)
        {
            yInvert.isOn = true;
        }

        bgm.value = bgmSlider;
        sfx.value = sfxSlider;
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

        SetBGVol(bgm.value);
        SetSFXVol(sfx.value);

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

        PlayerPrefs.Save();

        Back();
    }

    public void SetBGVol(float sliderValue)
    {
        bgmSlider = sliderValue;
        mixer.SetFloat("bgmVol", LinearToDecibel(sliderValue));
        PlayerPrefs.SetFloat("BGMVolume", bgmSlider);
    }

    public void SetSFXVol(float sliderValue)
    {
        sfxSlider = sliderValue;
        mixer.SetFloat("sfxVol", LinearToDecibel(sliderValue));
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider);
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