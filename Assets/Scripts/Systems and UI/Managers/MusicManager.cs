using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.SceneManagement;
using System;

public class MusicManager : MonoBehaviour
{


    public StudioEventEmitter musicEvent;
   


    

    private void Awake()
    {
        

        
    }

    // Start is called before the first frame update
    private void Start()
    { 

    }

  
    


    public void stopMusic(StudioEventEmitter studioEventEmitter)
    {
        studioEventEmitter.Stop();
    }
   

    // Update is called once per frame
    void Update()
    {
       
    }

 
}
