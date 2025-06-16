using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  ClearCounter : MonoBehaviour, IKitchenObjectParent
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform CounterTopPoint;
   
    [SerializeField] private KitchenObject kitchenObject;



    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.genericPrefab, CounterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetkitcheObjectParent(this);
            kitchenObjectTransform.localPosition = Vector3.zero;

         

        }
        else
        {
            kitchenObject.SetkitcheObjectParent(player);
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

    public Transform GetKitchenObjectFollowTransform()
    {
        return CounterTopPoint;
    }


    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
       
    }

    public KitchenObject GetKitchenObject() 
    { 
        return kitchenObject; 
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject() 
    {
        return kitchenObject != null; 
    }    
}
