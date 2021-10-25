using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Timer;

public class TimerTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (Timer.instance.timerActive == false)
        {
            Timer.instance.BeginTimer();
        }
    }
}
