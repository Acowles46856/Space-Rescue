using UnityEngine;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    public GameObject instructionsText;
    public PlayerMovement playerMovement;
    public Rigidbody playerRigidbody;

    // Other scripts can check whether SPACE has started the game
    public static bool gameStarted = false;

    void Start()
    {
        gameStarted = false;

        playerMovement.enabled = false;

        playerRigidbody.linearVelocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero;
        playerRigidbody.isKinematic = true;
    }

    void Update()
    {
        if (!gameStarted &&
            Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;

        instructionsText.SetActive(false);

        playerRigidbody.isKinematic = false;
        playerMovement.enabled = true;
    }
}