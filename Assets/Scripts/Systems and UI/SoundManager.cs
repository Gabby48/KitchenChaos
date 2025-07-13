using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SoundManager : MonoBehaviour
{
    public FMODUnity.EventReference deliverySuccess;
    public FMODUnity.EventReference deliveryFailure;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DeliveryManager_OnDeliverySuccess(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        Debug.Log("Sound Played");
        PlaySound(deliverySuccess, deliveryCounter.transform.position);
    }

    private void DeliveryManager_OnDeliveryFailure(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        Debug.Log("Sound Played");
        PlaySound(deliveryFailure, deliveryCounter.transform.position);
    }

    private void PlaySound(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}
