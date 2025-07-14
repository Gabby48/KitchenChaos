using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StartCountDownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
   

    // Start is called before the first frame update
   private void Start()
    {
        GameHandler.Instance.OnGameStateChanged += GameHandler_OnGameStateChanged;
        Hide();
        
    }

    private void GameHandler_OnGameStateChanged(object sender , System.EventArgs e)
    {
        if (GameHandler.Instance.isCountdowntoStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        countdownText.text = Mathf.Ceil(GameHandler.Instance.GetCountDowntoStartTimer()).ToString();

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
