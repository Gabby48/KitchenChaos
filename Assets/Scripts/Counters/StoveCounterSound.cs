using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class StoveCounterSound : MonoBehaviour
{

    [SerializeField] private StoveCounter stoveCounter;
    [SerializeField] private StudioEventEmitter studioEventEmitter;

     


    private void Awake()
    {
        
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
