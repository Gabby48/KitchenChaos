using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMOD.Studio;
using FMODUnity;
using System;

public class OptionsUI : MonoBehaviour
{
    [SerializeField] private Button musicButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button InteractButton;
    [SerializeField] private Button InteractAlternateButton;
    [SerializeField] private Button PauseButton;
    [SerializeField] private Button GamePadInteractButton;
    [SerializeField] private Button GamePadInteractAlternateButton;
    [SerializeField] private Button GamePadPauseButton;



    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI soundText;
    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI InteractText;
    [SerializeField] private TextMeshProUGUI InteractAlternateText;
    [SerializeField] private TextMeshProUGUI PauseText;
    [SerializeField] private TextMeshProUGUI GamePadInteractText;
    [SerializeField] private TextMeshProUGUI GamePadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI GamePadPauseText;


    private Action onCloseButtonAction;

    [SerializeField] private Transform presstoRebindTransform;

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
            onCloseButtonAction();
        
        });

        moveUpButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_UP);

        });

        moveDownButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Down);

        });

        moveLeftButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Left);

        });

        moveRightButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Right);

        });

        InteractButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Interact);

        });

        InteractAlternateButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Interact_Alternate);

        });

        PauseButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Pause);

        });

        GamePadInteractButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.GamePad_Interact);

        });

        GamePadInteractAlternateButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.GamePad_Interact_Alternate);

        });

        GamePadPauseButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.GamePad_Pause);

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

        moveUpText.text = GameInput.instance.GetBindingsText(GameInput.Binding.Move_UP);
        moveDownText.text = GameInput.instance.GetBindingsText(GameInput.Binding.Move_Down);
        moveLeftText.text = GameInput.instance.GetBindingsText(GameInput.Binding.Move_Left);
        moveRightText.text = GameInput.instance.GetBindingsText(GameInput.Binding.Move_Right);
        InteractText.text = GameInput.instance.GetBindingsText(GameInput.Binding.Interact);
        InteractAlternateText.text = GameInput.instance.GetBindingsText(GameInput.Binding.Interact_Alternate);
        PauseText.text = GameInput.instance.GetBindingsText(GameInput.Binding.Pause);
        GamePadInteractText.text = GameInput.instance.GetBindingsText(GameInput.Binding.GamePad_Interact);
        GamePadInteractAlternateText.text = GameInput.instance.GetBindingsText(GameInput.Binding.GamePad_Interact_Alternate);
        GamePadPauseText.text = GameInput.instance.GetBindingsText(GameInput.Binding.GamePad_Pause);



    }
    // Start is called before the first frame update
    private void Start()
    {
        GameHandler.Instance.OnGameUnpaused += GameHandler_OnGameUnPaused;
        UpdateVisual();
        Hide();
        HideRebind();

    }

    private void GameHandler_OnGameUnPaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Show(Action onClosedButtonAction)
    {
        this.onCloseButtonAction = onClosedButtonAction;

        gameObject.SetActive(true);

        soundButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }


    private void ChangeInputBinding()
    {

    }

    private void ShowRebind()
    {
        presstoRebindTransform.gameObject.SetActive(true);
      
    }

    private void HideRebind()
    {
        presstoRebindTransform.gameObject.SetActive(false);
    }
    

    private void RebindBinding(GameInput.Binding binding)
    {
        
        ShowRebind();
        GameInput.instance.RebindKey(binding, () =>
        {
            
            HideRebind();
            UpdateVisual();
        });

    }
}
