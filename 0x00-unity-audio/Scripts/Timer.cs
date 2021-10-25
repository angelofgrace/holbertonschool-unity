using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public Text timerText;
    public bool timerActive;
    public Text finalTime;
    public float elapsedTime;

    private TimeSpan timePlaying;

    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timerText.text = "0:00.00";
        timerActive = false;
    }

    public void BeginTimer()
    {
        timerActive = true;

        // if loading from pause menu
        if (PlayerPrefs.HasKey("pausedTime"))
        {
            elapsedTime = PlayerPrefs.GetFloat("pausedTime");
            PlayerPrefs.DeleteKey("pausedTime");
        }
        else
        {
            elapsedTime = 0f;
        }

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerActive = false;
    }

    public void Win()
    {
        finalTime.text = timerText.text;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerActive)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timerText.text = timePlayingStr;

            yield return null;
        }
    }
}

