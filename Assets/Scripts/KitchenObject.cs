using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectSO GetKitchenObjectSO()
    { 
        return kitchenObjectSO; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetkitcheObjectParent(IKitchenObjectParent kitchenObjectParent)
    {   
        if (this.kitchenObjectParent != null)
        {
           
            this.kitchenObjectParent.ClearKitchenObject();
          
        }
        
        
        this.kitchenObjectParent = kitchenObjectParent;
       
        
        if(kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("KitcheObjectParent Already has a Kitchen Object");
        }
        
        kitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetkitchenObjectParent()
    {
        return kitchenObjectParent;
    }
    

 }

