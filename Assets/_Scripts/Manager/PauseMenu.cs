using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private GameInput gameInput;
    public static bool IsPaused;

    private void Awake()
    {
        gameInput = FindAnyObjectByType<GameInput>();

        if (gameInput == null)
        {
            Debug.Log("gameInput is not found");
        }
    }
    //Pause Menu
    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (gameInput.GetPauseInput())
        {
            if (IsPaused) 
            { 
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitToDesktop()
    {
        Application.Quit();
        Debug.Log("Succesfully exit to desktop");
    }
    //Main Menu
    public void Chapter1()
    {
        SceneManager.LoadScene("Cutscene 2");
    }
    public void Chapter2()
    {
        SceneManager.LoadScene("Cutscene 2");
    }
}
