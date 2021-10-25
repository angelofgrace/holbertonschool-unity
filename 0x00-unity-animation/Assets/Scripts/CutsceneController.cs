using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CutsceneController : MonoBehaviour
{

    private PlayerController playerScript;
    
    public GameObject timer;
    public GameObject player;
    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerController>();
    }

    public void IntroAnimation()
    {
        player.SetActive(true);
        playerScript.enabled = true;
        timer.SetActive(true);
        mainCamera.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}
