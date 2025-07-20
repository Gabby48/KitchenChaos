using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StartCountDownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;

    private const string NUM_POPUP = "NumberPopUp";
    private Animator animator;
    private int previousCountDownNum;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
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
        int countDownNum = Mathf.CeilToInt(GameHandler.Instance.GetCountDowntoStartTimer());
        countdownText.text = countDownNum.ToString();

        if(countDownNum != previousCountDownNum)
        {
            previousCountDownNum = countDownNum;
            animator.SetTrigger(NUM_POPUP);
            SoundManager.instance.PlayCountDownSound();
        }

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
