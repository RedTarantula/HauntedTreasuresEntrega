using System;
using System.Collections;
using System.Collections.Generic;
using ECM.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameCanvas : MonoBehaviour
{
    public GameObject parentObj;
    public GameObject winObj;
    public GameObject loseObj;
    public Button menuButton;
    public Button exitButton;
    public FPS_CustomController _controller;
    public PlayerInfos Infos;
    public Zombie zombie;
    public PauseMenuController _pauseMenuController;

    private void Start()
    {
        menuButton.onClick.AddListener(GoMenu);
        exitButton.onClick.AddListener(ExitGame);
    }
    
    public void GameFinished(bool win)
    {
        Debug.Log("Finishing");
        zombie.GameOver();
        Infos.GameOver();
        _pauseMenuController.GameOver();
        
        _controller.pause = true;
        _controller.mouseLook.SetCursorLock(false);
        parentObj.SetActive(true);
        
        NewMethod();

        if (win)
        {
            winObj.SetActive(true);
            loseObj.SetActive(false);
        }
        else
        {
            winObj.SetActive(false);
            loseObj.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            NewMethod();
        }
    }

    private static void NewMethod()
    {
        Debug.Log(Cursor.visible);
        Debug.Log(Cursor.lockState);
    }

    private void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
