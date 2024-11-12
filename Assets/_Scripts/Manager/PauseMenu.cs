using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private GameInput gameInput;
    public static bool IsPaused;
    public GameObject[] background;
    private int index;
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
        index = PlayerPrefs.GetInt("index", 0);
        SetActiveBackground();
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

    public void Next()
    {
        index++;
        if (index >= background.Length) index = 0;
        SetActiveBackground();

    }

    public void Previous()
    {

        index--;

        if (index < 0)
            index = background.Length - 1;
        SetActiveBackground();

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
        SceneManager.LoadScene("Level 1");
    }
    public void Chapter2()
    {
        SceneManager.LoadScene("Cutscene 2");
    }
    void SetActiveBackground()
    {

        for (int i = 0; i < background.Length; i++)
        {
            background[i].SetActive(i == index);
        }

        PlayerPrefs.SetInt("index", index);
        PlayerPrefs.Save();
    }

}

