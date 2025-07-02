using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter, IHasProgress
{
    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;

    private float fryingTimer;
    private float burningTimer;
    private FryingRecipeSO fryingRecipeSO;


    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;

    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;

    public class OnStateChangedEventArgs:EventArgs
    {
        public State state;
    }
    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burnt,
    }


    private State state;

    // Start is called before the first frame update
    private void Start()
    {
        state = State.Idle;


    }

    // Update is called once per frame
    private void Update()
    {
        

        if (HasKitchenObject())
        {
            switch (state)
            {
                case State.Idle:
                    
                    break;
                case State.Frying:

                    fryingTimer += Time.deltaTime;

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = fryingTimer / fryingRecipeSO.fryingTimeMax
                    });


                    if (fryingTimer > fryingRecipeSO.fryingTimeMax)
                    {
                      

                        GetKitchenObject().DestroySelf();

                        KitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this);

                        fryingRecipeSO = whichFryingRecipe(GetKitchenObject().GetKitchenObjectSO());

                        state = State.Fried;


                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs()
                        {

                            state = state

                        });
                    }

                    burningTimer = 0f;

                               
                    break;
                case State.Fried:
                   
                    burningTimer += Time.deltaTime;

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = burningTimer / fryingRecipeSO.fryingTimeMax
                    });

                    if (burningTimer > fryingRecipeSO.fryingTimeMax)
                    {
                        GetKitchenObject().DestroySelf();

                        KitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this);
                        state = State.Burnt;

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs()
                        {

                            state = state

                        });

                       
                    }

                   
                    break;
                case State.Burnt:
                    break;
            }
        }

       
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

                    fryingRecipeSO = whichFryingRecipe(GetKitchenObject().GetKitchenObjectSO());


                    state = State.Frying;
                    fryingTimer = 0f;

                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs()
                    {

                        state = state

                    });

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = fryingTimer / fryingRecipeSO.fryingTimeMax
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
                state = State.Idle;

                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                {
                    progressNormalized = 1f
                });

                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs()
                {

                    state = state

                });



            }

        }

    }
 

    private bool HasRecipe(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = whichFryingRecipe(inputKitchenObjectSO);
        return fryingRecipeSO != null;

    }

    private FryingRecipeSO whichFryingRecipe(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray)
        {
            if (fryingRecipeSO.input == inputKitchenObjectSO)
            {
                return fryingRecipeSO;
            }


        }
        return null;

    }

    private KitchenObjectSO GetOutputforInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = whichFryingRecipe(inputKitchenObjectSO);
        if (fryingRecipeSO != null)
        {
            return fryingRecipeSO.output;
        }
        else
        {
            return null;
        }


    }

}
