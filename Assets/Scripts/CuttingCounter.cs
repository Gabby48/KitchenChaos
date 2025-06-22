using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;

    private int cuttingProgress;

    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public class OnProgressChangedEventArgs: EventArgs
    {
        public float progressNormalized;
    }

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasRecipe(player.GetKitchenObject().GetKitchenObjectSO()))
               {

                    player.GetKitchenObject().SetkitcheObjectParent(this);

                    cuttingProgress = 0;

                    CuttingRecipeSO cuttingRecipeSO = whichCuttingRecipe(GetKitchenObject().GetKitchenObjectSO());

                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs()
                    {
                        progressNormalized = (float)cuttingProgress / cuttingRecipeSO.maxCut
                    });

                }
                else
                {


                }

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
        if (HasKitchenObject() && HasRecipe(GetKitchenObject().GetKitchenObjectSO()))
        {
            cuttingProgress++;

            CuttingRecipeSO cuttingRecipeSO = whichCuttingRecipe(GetKitchenObject().GetKitchenObjectSO());

            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs()
            {
                progressNormalized = (float)cuttingProgress / cuttingRecipeSO.maxCut
            });

            if (cuttingProgress >= cuttingRecipeSO.maxCut)
            {
                KitchenObjectSO outputKitchenObjectSO = GetOutputforInput(GetKitchenObject().GetKitchenObjectSO());
                GetKitchenObject().DestroySelf();

                KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);

            }



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
        CuttingRecipeSO cuttingRecipeSO = whichCuttingRecipe(inputKitchenObjectSO);
        if (cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.output;
        }
        else
        {
            return null;
        }

   
    }


    private bool HasRecipe(KitchenObjectSO inputKitchenObjectSO)
    {
        CuttingRecipeSO cuttingRecipeSO = whichCuttingRecipe(inputKitchenObjectSO);
        return cuttingRecipeSO != null;
        
    }
    private CuttingRecipeSO whichCuttingRecipe(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO ;
            }


        }
        return null;    
        
    }

}
