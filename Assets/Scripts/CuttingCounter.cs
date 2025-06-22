using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;

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

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject())
        {
            KitchenObjectSO outputKitchenObjectSO = GetOutputforInput(GetKitchenObject().GetKitchenObjectSO());
            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);


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

    private KitchenObjectSO GetOutputforInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }

}
