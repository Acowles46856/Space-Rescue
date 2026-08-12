using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class CrystalCounterUI : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public GameObject missionCompleteText;

    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        counterText.text = "Energy Crystals: " +
                           CollectCrystal.crystalsCollected +
                           "/5";

        // Do not allow pause or restart until SPACE starts the game
        if (!GameStart.gameStarted)
        {
            return;
        }

        // R = Restart anytime after game starts
        if (Keyboard.current != null &&
            Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartGame();
            return;
        }

        // P = Pause / Resume
        if (Keyboard.current != null &&
            Keyboard.current.pKey.wasPressedThisFrame)
        {
            TogglePause();
        }

        // Mission Complete
        if (CollectCrystal.crystalsCollected >= 5)
        {
            missionCompleteText.SetActive(true);
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            Debug.Log("GAME PAUSED");
        }
        else
        {
            Time.timeScale = 1f;
            Debug.Log("GAME RESUMED");
        }
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        CollectCrystal.crystalsCollected = 0;
        GameStart.gameStarted = false;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}