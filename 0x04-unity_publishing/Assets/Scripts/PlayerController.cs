using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;
    public GameObject outcomeBG;


    private Scene scene;
    private Rigidbody rigid;
    private int score = 0;        
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        rigid = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        rigid.AddForce (moveDirection * speed);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            score += 1;
            /// Debug.Log("Score: " + score);
            this.SetScoreText();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            /// Debug.Log("Health: " + health);
            this.SetHealthText();
            if (health == 0)
            {
                StartCoroutine(LoadScene(3));
                
            }
        }
        if (other.gameObject.tag == "Goal")
        {
            /// Debug.Log("You win!");
            this.WinOutcome();
        }
    }

    void SetScoreText()
    {
        scoreText.text = string.Format("Score: {0}", score);

    }

    void SetHealthText()
    {
        healthText.text = string.Format("Health: {0}", health);
    }

    void WinOutcome()
    {
        outcomeBG.SetActive(true);
        winLoseBG.color = Color.green;
        winLoseText.text = string.Format("You Win!");
        winLoseText.color = Color.black;
    }

    void LoseOutcome()
    {
        outcomeBG.SetActive(true);
        winLoseBG.color = Color.red;
        winLoseText.text = string.Format("Game Over!");
        winLoseText.color = Color.white;
    }

    IEnumerator LoadScene(float seconds)
    {
        LoseOutcome();
        yield return new WaitForSecondsRealtime(seconds);
        SceneManager.LoadScene(scene.name);
    }

}
