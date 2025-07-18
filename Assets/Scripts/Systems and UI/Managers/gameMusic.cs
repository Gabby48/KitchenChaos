using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMusic : MusicManager
{
    [SerializeField] private GameOverUI gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.OnStartOver += GameOverUI_OnStartOver;
        gameOverUI.OnMenuSelect += GameOverUI_OnMenuSelect;
    }

    private void GameOverUI_OnStartOver(object sender, System.EventArgs e)
    {
        stopMusic(musicEvent);
        Debug.Log("music has stopped");
    }

    private void GameOverUI_OnMenuSelect(object sender, System.EventArgs e)
    {
        stopMusic(musicEvent);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
