using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using static Timer;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseUI;
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    bool Paused = false;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Paused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        // Stop time-based physics, toggle bool, bring up menu
        Time.timeScale = 0.0f;
        Paused = true;
        PauseUI.SetActive(true);

        // Record time and place for potential reload
        PlayerPrefs.SetFloat("pausedTime", Timer.instance.elapsedTime);
        PlayerPrefs.SetFloat("playerTransformX", player.transform.position[0]);
        PlayerPrefs.SetFloat("playerTransformY", player.transform.position[1]);
        PlayerPrefs.SetFloat("playerTransformZ", player.transform.position[2]);

        paused.TransitionTo(.01f);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        Paused = false;
        PauseUI.SetActive(false);

        unpaused.TransitionTo(.01f);
    }

    public void Restart()
    {
        PlayerPrefs.DeleteKey("pausedTime");
        PlayerPrefs.DeleteKey("playerTransformX");
        PlayerPrefs.DeleteKey("playerTransformY");
        PlayerPrefs.DeleteKey("playerTransformZ");
        PlayerPrefs.DeleteKey("navFromOptions");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }

    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        Resume();
        SceneManager.LoadScene("Options");
    }
}