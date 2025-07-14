using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlateCompleteVisual;

public class PlateIconsUi : MonoBehaviour
{

    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private Transform iconTemplate;


    private void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;


    }


    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIgredientAddeEventArgs e)
    {
        UpdateVisuals();
    }


    private void UpdateVisuals()
    {
        foreach(Transform child in transform)
        {
            if(child == iconTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (KitchenObjectSO kitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList()) 
        {
          Transform iconTransform = Instantiate(iconTemplate, transform);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<PlateIconSingleUI>().SetKitchenObjectSO(kitchenObjectSO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
