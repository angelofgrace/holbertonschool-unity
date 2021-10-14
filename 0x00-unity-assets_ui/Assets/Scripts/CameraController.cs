using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    public bool isInverted = false;
    public CinemachineFreeLook cinemachineFreeLook;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("YInvert") == 1)
        {
            isInverted = true;
        }
        else
        {
            isInverted = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInverted == true)
        {
            cinemachineFreeLook.m_YAxis.m_InvertInput = true;
        }
        else
        {
            cinemachineFreeLook.m_YAxis.m_InvertInput = false;
        }
    }
}
