using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;

public class StoveCounterSound : MonoBehaviour
{

    [SerializeField] private StoveCounter stoveCounter;
    [SerializeField] public StudioEventEmitter studioEventEmitter;

     


    private void Awake()
    {
        
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
        GameHandler.Instance.OnGameStateChanged+= GameHandler_OnGameStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool playSound = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;

        if (playSound)
        {
            studioEventEmitter.Play();
           
        }
        else
        {
            studioEventEmitter.Stop();
           
        }
    }

    private void GameHandler_OnGameStateChanged(object sender, System.EventArgs e)
    {
        if (GameHandler.Instance.isGameOver())
        {
            studioEventEmitter.Stop();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
