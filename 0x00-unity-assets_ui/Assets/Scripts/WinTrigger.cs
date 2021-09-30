using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Timer;

public class WinTrigger : MonoBehaviour
{
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Timer.instance.EndTimer();
            timerText.fontSize = 60;
            timerText.color = Color.green;
        }
    }
}