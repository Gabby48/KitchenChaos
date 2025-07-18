using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class PauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenu);

        });

        resumeButton.onClick.AddListener(() =>
        {
            GameHandler.Instance.SwitchPauseState();

        });
    }

    // Start is called before the first frame update
    private void Start()
    {
        GameHandler.Instance.OnGamePaused += GameHandler_OnGamePaused;
        GameHandler.Instance.OnGameUnpaused += GameHandler_OnGameUnPaused;
        Hide();
    }

    private void GameHandler_OnGamePaused(object sender, System.EventArgs e)
    {
        Show();
        
    }

    private void GameHandler_OnGameUnPaused(object sender, System.EventArgs e)
    {
        Hide();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
