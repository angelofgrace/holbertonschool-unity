using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CutsceneController : MonoBehaviour
{

    public Animator animator;
    private PlayerController playerScript;
    
    public GameObject timer;
    public GameObject playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = playerController.GetComponent<PlayerController>();
        IntroAnimation();
    }

    private void IntroAnimation()
    {
        animator.Play("Intro01");
        StartCoroutine("OnIntroComplete");
    }

    IEnumerator OnIntroComplete()
    {
        while(animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
                yield return null;
        }

        playerScript.enabled = true;
        timer.SetActive(true);
        animator.Play("MainCamera");
    }
}
