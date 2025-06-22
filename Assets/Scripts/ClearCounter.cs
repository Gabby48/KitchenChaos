using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {

        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetkitcheObjectParent(this);
            }
            else
            {

            }

        }
        else
        {

            if (player.HasKitchenObject()) 
            { 
                
            }
            else
            {
                this.GetKitchenObject().SetkitcheObjectParent(player);
                
           

            }

        }
    }




        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
  private void Update()
    {
        
       
        
        
    }

}
