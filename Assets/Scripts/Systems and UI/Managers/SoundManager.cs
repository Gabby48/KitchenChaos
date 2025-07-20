using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class SoundManager : MonoBehaviour
{
    private const string STORED_SOUND_EFFECTS_VOLUME = "SoundEffectsVolume";

    [SerializeField] private FMODUnity.EventReference deliverySuccess;
    [SerializeField] private FMODUnity.EventReference deliveryFailure;
    [SerializeField] private FMODUnity.EventReference chop;
    [SerializeField] private FMODUnity.EventReference pickUp;
    [SerializeField] private FMODUnity.EventReference drop;
    [SerializeField] private FMODUnity.EventReference trash;
    [SerializeField] private FMODUnity.EventReference footsteps;
    [SerializeField] private FMODUnity.EventReference warning;
    [SerializeField] private FMODUnity.EventReference Countdownwarning;



    public Vector3 cameraposition;

    public Bus soundBus;


    private float fullVolume = 1.0f;
    private float muteVolume = 0f;
    private float volume = 0.5f;
    private float volumeStep = 0.1f;

    public static SoundManager instance { get; private set; }

    private void Awake()
    {
       volume =  PlayerPrefs.GetFloat(STORED_SOUND_EFFECTS_VOLUME, 0.5f);
        soundBus = RuntimeManager.GetBus("bus:/Sound");
        

        instance = this;

    }



    public void ChangeSoundVolume()
    {

        soundBus.setVolume(volume);

        if (volume >= fullVolume)
        {
            volume = muteVolume;

        }
        else
        {
            volume = volume + volumeStep;

        }

        PlayerPrefs.SetFloat(STORED_SOUND_EFFECTS_VOLUME, volume);
        PlayerPrefs.Save();

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


    public void PlayCountDownSound()
    {
        PlaySound(Countdownwarning, Vector3.zero);
    }

    public void PlayWarningSound(Vector3 position)
    {
        PlaySound(warning, position);
    }
    public float GetVolume()
    {
        return volume;
    }
}
