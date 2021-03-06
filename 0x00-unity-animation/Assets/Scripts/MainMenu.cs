using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        // Set current scene pref for navigation
        PlayerPrefs.DeleteKey("navFromOptions");
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelSelect(int level)
    {
        SceneManager.LoadScene("Level0" + level);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
