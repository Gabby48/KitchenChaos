using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private Player player;
    private float stepTimer;
    private float stepTimerMax = 0.1f;
    

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        stepTimer-= Time.deltaTime;

        if (stepTimer < 0f)
        {
            stepTimer = stepTimerMax;

            if(player.IsWalking())
            {
                SoundManager.instance.PlayFootsteps(player.transform.position);
              

            }
            
        }
      
    }
}
