using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;


    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSpawned += DeliveryManager_OnRecipeSpawned;
        DeliveryManager.Instance.OnRecipeDelivered += DeliveryManager_OnRecipeDelivered;
        UpdateVisual();
    }


    private void DeliveryManager_OnRecipeSpawned (object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void DeliveryManager_OnRecipeDelivered(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private  void UpdateVisual()
    {
        foreach(Transform child in container)
        {
            if (child == recipeTemplate) continue;
             Destroy(child.gameObject);
        }

       foreach (OrderRecipeSO orderRecipeSO in DeliveryManager.Instance.GetWattingRecipeList())
        {
            Transform recipeTransform = Instantiate(recipeTemplate,container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.GetComponent<DeliveryManagerSingleUI>().SetRecipeSO(orderRecipeSO);
        }
    }
}
