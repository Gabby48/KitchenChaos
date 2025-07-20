using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GamePlayingTimerUi : MonoBehaviour
{
    [SerializeField] private Image clockTimer;
    [SerializeField] private TextMeshProUGUI timerText;


    private void Awake()
    {
      
    }


    // Start is called before the first frame update
    void Start()
    {
      
    }


 

    // Update is called once per frame
    private void Update()
    {
      
        clockTimer.fillAmount = GameHandler.Instance.GetPlayingTimerNormalized();
        
        timerText.text = GameHandler.Instance.GetTimeinMinutes().ToString() + ":" + GameHandler.Instance.GetTimeinSecond().ToString();

    }
}
