using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliverd;

    
    // Start is called before the first frame update
    void Start()
    {
        GameHandler.Instance.OnGameStateChanged += GameHandler_OnGameStateChanged;
        Hide();
    }

    private void GameHandler_OnGameStateChanged(object sender, System.EventArgs e)
    {
      if (GameHandler.Instance.isGameOver())
        {
            Show();
            recipesDeliverd.text = DeliveryManager.Instance.GetRecipesDelivered().ToString();
        }
        else
        {
            Hide();

        }
        
          
        
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
