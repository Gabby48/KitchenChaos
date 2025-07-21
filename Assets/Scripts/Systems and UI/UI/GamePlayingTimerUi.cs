using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GamePlayingTimerUi : MonoBehaviour
{
    [SerializeField] private Image clockTimer;
    [SerializeField] private TextMeshProUGUI timerText;

    private string defaultText;


    private void Awake()
    {
        
        defaultText =  timerText.text;
      
    }


    // Start is called before the first frame update
    void Start()
    {
      
    }


 

    // Update is called once per frame
    private void Update()
    {
      
        

        if (GameHandler.Instance.isGamePlaying())
        {
            timerText.text = GameHandler.Instance.GetTimeinMinutesandSeconds();
            clockTimer.fillAmount = GameHandler.Instance.GetPlayingTimerNormalized();
        }
        else
        {
            timerText.text = defaultText;
            clockTimer.fillAmount = 1f;

        }
        

    }
}
