using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    
    
    public static MainMenuUI Instance { get; private set; }
    public event EventHandler OnGamePlay;
    

    private void Awake()
    {
        Instance = this;

        playButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
            OnGamePlay?.Invoke(this, EventArgs.Empty);
            
           
        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();

        });


        Time.timeScale = 1f;


    }


   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
