using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SoundManager : MonoBehaviour
{
    

    [SerializeField] private FMODUnity.EventReference deliverySuccess;
    [SerializeField] private FMODUnity.EventReference deliveryFailure;
    [SerializeField] private FMODUnity.EventReference chop;
    [SerializeField] private FMODUnity.EventReference pickUp;
    [SerializeField] private FMODUnity.EventReference drop;
    [SerializeField] private FMODUnity.EventReference trash;
    [SerializeField] private FMODUnity.EventReference footsteps;



    public Vector3 cameraposition;
    
    public static SoundManager instance { get; private set; }

    private void Awake()
    {
        instance = this;

    }

    // Start is called before the first frame update
    private void Start()
    {
        cameraposition = Camera.main.transform.position;    

        DeliveryManager.Instance.OnDeliverySuccess += DeliveryManager_OnDeliverySuccess;
        DeliveryManager.Instance.OnDeliveryFailure += DeliveryManager_OnDeliveryFailure;

        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;

        Player.Instance.OnPickUp += Player_OnPickup;
        BaseCounter.OnAnyDrop += Counter_OnAnyDrop;

        TrashCounter.OnAnyTrash += Trash_OnAnyTrash;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CuttingCounter_OnAnyCut(object sender, System.EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(chop, cuttingCounter.transform.position);
    }



    private void DeliveryManager_OnDeliverySuccess(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(deliverySuccess, deliveryCounter.transform.position);
    }

    private void DeliveryManager_OnDeliveryFailure(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(deliveryFailure, deliveryCounter.transform.position);
    }


    private void Player_OnPickup(object sender, System.EventArgs e) 
    {
        PlaySound(pickUp, Player.Instance.transform.position);
    }

    private void Counter_OnAnyDrop(object sender, System.EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySound(drop,baseCounter.transform.position);
    }


    private void Trash_OnAnyTrash(object sender, System.EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;
        PlaySound(trash, trashCounter.transform.position);

    }

    public void PlayFootsteps(Vector3 position)
    {
        PlaySound(footsteps, position);
    }
    private void PlaySound(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}
