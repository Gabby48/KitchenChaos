using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance { get; private set; }

    public event EventHandler OnGameStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;

    [SerializeField] private GameOverUI gameOverUI;

    [SerializeField] private StoveCounterSound stoveCounterSound;

    private enum State
    {
        WaitingtoStart,
        CountdowntoStart,
        GamePlaying,
        GameOver,
    }

    private State state;
    [SerializeField] private float waitingtoStartTimer = 1f;
    [SerializeField] private float countdownTimer = 3f;
    [SerializeField] private float gamePlayingTimer;
    [SerializeField] private float gamePlayingTimerMax = 120f;
    private bool isGamePaused = false;



    private void Awake()
    {
        Instance = this;
        state = State.WaitingtoStart;
    }

    // Start is called before the first frame update
    private void Start()
    {
        GameInput.instance.OnPause += GameInput_OnPause;
        gameOverUI.OnStartOver += GameOverUI_OnStartOver;
      

    }

    private void GameOverUI_OnStartOver(object sender, EventArgs e)
    {
        Loader.Load(Loader.Scene.GameScene);
        
        state = State.WaitingtoStart;
    }

    private void GameInput_OnPause(object sender, EventArgs e)
    {
        SwitchPauseState();
    }



    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.WaitingtoStart:

                waitingtoStartTimer -= Time.deltaTime;

                if (waitingtoStartTimer < 0f)
                {
                  
                    state = State.CountdowntoStart;
                    OnGameStateChanged?.Invoke(this, EventArgs.Empty);
                }

                break;
            case State.CountdowntoStart:

                countdownTimer -= Time.deltaTime;

                if (countdownTimer < 0f)
                {
                    state = State.GamePlaying;
                    gamePlayingTimer = gamePlayingTimerMax;
                    OnGameStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:

                gamePlayingTimer -= Time.deltaTime;

                if (gamePlayingTimer < 0f)
                {
                    state = State.GameOver;
                    OnGameStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                
                waitingtoStartTimer = 1f;
               

                break;

        }

        

    }




    public bool isGamePlaying()
    {
        return state == State.GamePlaying;

    }

    public bool isCountdowntoStartActive()
    {
        return state == State.CountdowntoStart;
    }

    public float GetCountDowntoStartTimer()
    {
        return countdownTimer;
    }

    public bool isGameOver()
    {
        return state == State.GameOver;
    }

    public float GetPlayingTimerNormalized()
    {
        return  gamePlayingTimer/gamePlayingTimerMax;
    }
 


    public  void SwitchPauseState()
    {
        
        isGamePaused = !isGamePaused;
        if (isGamePaused) 
        {
            OnGamePaused?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 0f;
           
            
        }
        else
        {
            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 1f;
            
        }

    }

   
}
