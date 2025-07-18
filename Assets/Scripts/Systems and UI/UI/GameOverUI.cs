using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliverd;
    [SerializeField] private Button startOver;
    [SerializeField] private Button mainMenu;
    public event EventHandler OnStartOver;
    public event EventHandler OnMenuSelect;



    private void Awake()
    {
        startOver.onClick.AddListener(() =>
        {
           OnStartOver?.Invoke(this, EventArgs.Empty);

        });

        mainMenu.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenu);
            OnMenuSelect?.Invoke(this, EventArgs.Empty);

        });
    }
    
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
