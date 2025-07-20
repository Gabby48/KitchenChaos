using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatesCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;

    private float spawnPlateTimer;
    private float plateTimerMax = 4f;
    private int platesSpawned;
    private int maxPlates = 4;

    public event EventHandler OnPlateSpawn;
    public event EventHandler OnPlateTaken;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  private void Update()
    {
        spawnPlateTimer += Time.deltaTime;

        if (spawnPlateTimer > plateTimerMax) 
        {
            spawnPlateTimer = 0;

            if (GameHandler.Instance.isGamePlaying() && platesSpawned < maxPlates)
            {
                platesSpawned++;
                OnPlateSpawn?.Invoke(this , EventArgs.Empty);
            }
        }

     
    }


    public override void Interact(Player player)
    {
       

            if (player.HasKitchenObject())
            {

            }
            else
            {
                if(platesSpawned> 0)
            {
                platesSpawned--;
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO,player);
                OnPlateTaken?.Invoke(this, EventArgs.Empty);
                
            }
                




            }

        


    }
}
