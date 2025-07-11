using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoverCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    [SerializeField] private GameObject stoveOn;
    [SerializeField] private GameObject smoke;
    [SerializeField] private StoveCounter stoveCounter;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private float particleSpeed;
    bool showVisual;
    bool smokeVisual;


    // Start is called before the first frame update
    void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }


    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        Debug.Log("state changed");
        showVisual = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried || e.state == StoveCounter.State.Burnt;
        smokeVisual = e.state == StoveCounter.State.Burnt;
        OnorOff();
        Smoking();
        ChangeParticleSpeed(particleSpeed);


       if(e.state ==  StoveCounter.State.Fried)
        {
            particleSpeed = 9f;
        }
        else if (e.state == StoveCounter.State.Idle)
        {
            particleSpeed = 4f;
        }
        else if (e.state == StoveCounter.State.Burnt)
        {
            particleSpeed = 15f;
            
        }
        else
        {

            particleSpeed = 4f;
        }
       
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnorOff()
    {
        stoveOn.SetActive(showVisual);
        particles.SetActive(showVisual);
    }
    
    private void ChangeParticleSpeed( float speed)
    {
        var mainModule = particleSystem.main;
        mainModule.startSpeed = speed;

    }

    private void Smoking()
    {
        smoke.SetActive(smokeVisual);
    }




}
