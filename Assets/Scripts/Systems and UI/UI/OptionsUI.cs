using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMOD.Studio;
using FMODUnity;

public class OptionsUI : MonoBehaviour
{
    [SerializeField] private Button musicButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button closeButton;
    
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI soundText;

    private const string STORED_MUSIC_VOLUME = "MusicVolume";

    private Bus musicBus;

    public static OptionsUI instance {  get; private set; }

    private float fullVolume = 1.0f;
    private float muteVolume = 0f;
    private float volume = 0.5f;
    private float volumeStep = 0.1f;

    private void Awake()
    {
        instance = this;

        musicBus = RuntimeManager.GetBus("bus:/Music Fader");
        volume = PlayerPrefs.GetFloat(STORED_MUSIC_VOLUME, 0.5f);

        musicButton.onClick.AddListener(() =>
        {
            ChangeMusicVolume();
            UpdateVisual();

        });


        soundButton.onClick.AddListener(() =>
        {
            SoundManager.instance.ChangeSoundVolume();
            UpdateVisual();

        });
        closeButton.onClick.AddListener(() => 
        {
            Hide();
        
        });





    }

    public void ChangeMusicVolume()
    {

        musicBus.setVolume(volume);

        if (volume >= fullVolume)
        {
            volume = muteVolume;
            
        }
        else
        {
            volume = volume + volumeStep;
            
        }

        PlayerPrefs.SetFloat(STORED_MUSIC_VOLUME, volume);
        PlayerPrefs.Save();
    }

    private void UpdateVisual()
    {
        musicText.text = "Music Volume: " + Mathf.Round((volume * 10f));
        soundText.text =  " Sound Volume: " + Mathf.Round((SoundManager.instance.GetVolume() * 10f));
    }
    // Start is called before the first frame update
    private void Start()
    {
        GameHandler.Instance.OnGameUnpaused += GameHandler_OnGameUnPaused;
        UpdateVisual();
        Hide();

    }

    private void GameHandler_OnGameUnPaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
