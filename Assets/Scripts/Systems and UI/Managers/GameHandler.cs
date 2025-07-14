using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance {  get; private set; }

    public event EventHandler OnGameStateChanged;


    private enum State
    {
        WaitingtoStart,
        CountdowntoStart,
        GamePlaying,
        GameOver,
    }

    private State state;
    private float waitingtoStartTimer = 1f;
    private float countdownTimer = 3f;
    private float gamePlayingTimer = 120f;


    private void Awake()
    {
        Instance = this;
        state = State.WaitingtoStart;
    }

    // Start is called before the first frame update
    void Start()
    {

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
}
