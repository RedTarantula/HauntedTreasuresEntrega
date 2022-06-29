using System;
using System.Collections;
using System.Collections.Generic;
using ECM.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject parentObj;
    public Button closePauseMenuButton;
    public Button menuButton;
    public Button exitButton;
    public FPS_CustomController _controller;
    public bool canPause;

    private void Start()
    {
        closePauseMenuButton.onClick.AddListener(ClosePause);
            menuButton.onClick.AddListener(GoMenu);
        exitButton.onClick.AddListener(ExitGame);
        canPause = true;

    }

    private void Update()
    {
        if (!canPause)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Pause))
        {
            if (parentObj.activeSelf)
            {
                ClosePause();
            }
            else
            {
                OpenPause();
            }
        }
    }

    private void OpenPause()
    {
        _controller.mouseLook.SetCursorLock(false);
        parentObj.SetActive(true);
        _controller.pause = true;
    }
    public void ClosePause()
    {
        _controller.mouseLook.SetCursorLock(true);
        Cursor.lockState = CursorLockMode.Locked;
        parentObj.SetActive(false);
        _controller.pause = false;

    }

    private void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        ClosePause();
        canPause = false;
    }
}
