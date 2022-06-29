using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
  public Button playButton;
  public Button exitButton;

  private void Start()
  {
    playButton.onClick.AddListener(PlayGame);
    exitButton.onClick.AddListener(ExitGame);
  }

  private void ExitGame()
  {
    Application.Quit();
  }

  private void PlayGame()
  {
    SceneManager.LoadScene("Test");
  }
}
