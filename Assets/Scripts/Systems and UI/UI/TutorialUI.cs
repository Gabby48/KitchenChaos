using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TutorialUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI keymoveUpText;
    [SerializeField] private TextMeshProUGUI keymoveDownText;
    [SerializeField] private TextMeshProUGUI keymoveLeftText;
    [SerializeField] private TextMeshProUGUI keymoveRightText;
    [SerializeField] private TextMeshProUGUI keyInteractText;
    [SerializeField] private TextMeshProUGUI keyInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyPauseText;
    [SerializeField] private TextMeshProUGUI keyGamePadInteractText;
    [SerializeField] private TextMeshProUGUI keyGamePadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyGamePadPauseText;


    private void UpdateVisual()
    {
      
        keymoveUpText.text = GameInput.instance.GetBindingsText(GameInput.Binding.Move_UP);
        keymoveDownText.text = GameInput.instance.GetBindingsText(GameInput.Binding.Move_Down);
        keymoveLeftText.text = GameInput.instance.GetBindingsText(GameInput.Binding.Move_Left);
        keymoveRightText.text = GameInput.instance.GetBindingsText(GameInput.Binding.Move_Right);
        keyInteractText.text = GameInput.instance.GetBindingsText(GameInput.Binding.Interact);
        keyInteractAlternateText.text = GameInput.instance.GetBindingsText(GameInput.Binding.Interact_Alternate);
        keyPauseText.text = GameInput.instance.GetBindingsText(GameInput.Binding.Pause);
        keyGamePadInteractText.text = GameInput.instance.GetBindingsText(GameInput.Binding.GamePad_Interact);
        keyGamePadInteractAlternateText.text = GameInput.instance.GetBindingsText(GameInput.Binding.GamePad_Interact_Alternate);
        keyGamePadPauseText.text = GameInput.instance.GetBindingsText(GameInput.Binding.GamePad_Pause);



    }

    // Start is called before the first frame update
    private void Start()
    {
        GameInput.instance.OnRebind += GameInput_OnRebind;
        GameHandler.Instance.OnGameStateChanged += GameHandler_OnGameStateChanged;
        UpdateVisual();
        Show();
    }


    private void GameHandler_OnGameStateChanged(object sender , System.EventArgs e)
    {
        if (GameHandler.Instance.isCountdowntoStartActive())
        {
            Hide();
        }
        
    }

    private void GameInput_OnRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

        // Update is called once per frame
        void Update()
    {
        
    }



    private void Show()
    {
        gameObject.SetActive(true);
       
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
