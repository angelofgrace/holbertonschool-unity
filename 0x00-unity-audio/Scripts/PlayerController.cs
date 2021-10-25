using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static Timer;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{   

    [SerializeField]
    private InputActionReference movementControl;
    [SerializeField]
    private InputActionReference jumpControl;
    [SerializeField] 
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 4f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraMainTransform;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        cameraMainTransform = Camera.main.transform;

        // record current scene for navigation
        PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);

        // load previous location and time if returning
        if (PlayerPrefs.HasKey("navFromOptions") == true)
        {
            PlayerPrefs.DeleteKey("navFromOptions");

            this.transform.position = this.transform.position + new Vector3(PlayerPrefs.GetFloat("playerTransformX"), PlayerPrefs.GetFloat("playerTransformY"), PlayerPrefs.GetFloat("playerTransformZ"));

        //    this.transform.position[0] = PlayerPrefs.GetFloat("playerTransformX");
        //    this.transform.position[1] = PlayerPrefs.GetFloat("playerTransformY");
        //    this.transform.position[2] = PlayerPrefs.GetFloat("playerTransformZ");
            Timer.instance.elapsedTime = PlayerPrefs.GetFloat("pausedTime");
        }
    }

    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
    }

    private void onDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
    }

    void Update()
    {
        // only apply gravity in the air /  don't bounce on landing
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // base movement on 3rd person camera perspective / direction
        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (jumpControl.action.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // movement nuance math that I don't really understand
        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        }

        // gravity application / falling movement
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}