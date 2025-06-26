using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoverCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    [SerializeField] private GameObject stoveOn;
    [SerializeField] private StoveCounter stoveCounter;
    [SerializeField] private ParticleSystem particleSystem;
    bool showVisual;


    // Start is called before the first frame update
    void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }


    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        showVisual = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried || e.state == StoveCounter.State.Burnt;
        OnorOff();


        if(e.state ==  StoveCounter.State.Fried || e.state == StoveCounter.State.Burnt)
        {
            var mainModule = particleSystem.main;
            mainModule.startSpeed = 9f;
        }
        else
        {
            var mainModule = particleSystem.main;
            mainModule.startSpeed = 4f;
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


}
