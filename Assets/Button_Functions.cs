using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    public static bool Paused = false; // Default to not paused
    public GameObject Player;
    public GameObject CreditsCanvas;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Should Quit the game");
    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Player.SetActive(true);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    private void TogglePauseMenu()
    {
        if (Paused)
        {
            PauseMenuCanvas.SetActive(false);
            Player.SetActive(true);
            Time.timeScale = 1f;
            Paused = false;
        }
        else
        {
            PauseMenuCanvas.SetActive(true);
            Player.SetActive(false); // Optional: If you want to hide the player during pause
            Time.timeScale = 0f;
            Paused = true;
        }
    }

    public void Credits()
    {
        CreditsCanvas.SetActive(true);
    }
    public void BackControls()
    {
        CreditsCanvas.SetActive(false);
    }
}
