using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
   public static DeliveryManager Instance {  get; private set; }

    [SerializeField] private RecipeListSO recipeListSO;

    private List<OrderRecipeSO> waitingRecipeSOList;
    private float recipeGeneratorTimer;
    private float recipeTimerMax = 4f;
    private int waitingRecipeMax = 4;

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeDelivered;

    private void Awake()
    {
        Instance = this;
        waitingRecipeSOList = new List<OrderRecipeSO>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        recipeGeneratorTimer -= Time.deltaTime;
        if (recipeGeneratorTimer < 0f)
        {
            recipeGeneratorTimer = recipeTimerMax;

            if(waitingRecipeSOList.Count < waitingRecipeMax)
            {
                OrderRecipeSO waitingRecipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];
                waitingRecipeSOList.Add(waitingRecipeSO);
                Debug.Log(waitingRecipeSO.recipeName);

                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }

           

        }
    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    { 
        for (int i = 0; i < waitingRecipeSOList.Count; i++)
        {
            OrderRecipeSO waitingRecipeSO = waitingRecipeSOList[i];

            if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {
                bool plateContentMatchesRecipe = true;
                foreach(KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    bool ingredientFound = false;

                    foreach(KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
                    {
                        if (plateKitchenObjectSO == recipeKitchenObjectSO)
                        {
                            ingredientFound = true;
                            break;
                        }
                    }

                    if (!ingredientFound)
                    {
                        plateContentMatchesRecipe = false;
                    }
                }
                if(plateContentMatchesRecipe)
                
                {
                    Debug.Log("Recipe Correct");
                    waitingRecipeSOList.RemoveAt(i);
                    OnRecipeDelivered?.Invoke(this, EventArgs.Empty);
                    return;
                }
                
            }
        }

        Debug.Log("Recipe Not Delivered"); 
    }

    public List<OrderRecipeSO> GetWattingRecipeList ()
    {
        return waitingRecipeSOList;
    }

}
