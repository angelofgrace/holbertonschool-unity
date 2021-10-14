using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
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
}
