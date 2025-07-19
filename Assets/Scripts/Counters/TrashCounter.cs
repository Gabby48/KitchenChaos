using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnAnyTrash;


  new public static void ResetStaticData()
    {
        OnAnyTrash = null;
    }
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            OnAnyTrash?.Invoke(this,EventArgs.Empty);
            player.GetKitchenObject().DestroySelf();
        }
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
