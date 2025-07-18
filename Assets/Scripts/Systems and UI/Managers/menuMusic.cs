using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMusic : MusicManager
{
    private void Start()
    {
        MainMenuUI.Instance.OnGamePlay += MainMenuUI_OnGamePlay;
    }

    private void MainMenuUI_OnGamePlay(object sender , System.EventArgs e)
    {
        stopMusic(musicEvent);
    }

}
