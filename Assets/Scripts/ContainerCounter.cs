using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter
{

    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
      
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.genericPrefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetkitcheObjectParent(player);
            OnPlayerGrabbedObject?.Invoke(this,EventArgs.Empty);
           



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
