using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeliverRecipeUI : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI deliveryText;
    [SerializeField] private Color successColor;
    [SerializeField] private Color failedColor;
    [SerializeField] private Sprite successSprite;
    [SerializeField] private Sprite failedSprite;
    private const string SUCCESSFULMESSAGE = "Successful\nDelivery";
    private const string FAILUREMESSAGE = "Wrong\nRecipe";
    private const string POPUPTRIGGER = "PopUP";

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    private void Start()
    {
        DeliveryManager.Instance.OnDeliverySuccess += DeliveryManager_OnDeliverySuccess;
        DeliveryManager.Instance.OnDeliveryFailure += DeliveryManager_OnDeliveryFailure;
       

        gameObject.SetActive(false);
    }



    private void DeliveryManager_OnDeliveryFailure(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        animator.SetTrigger(POPUPTRIGGER);
        backgroundImage.color = failedColor;
        iconImage.sprite = failedSprite;
        deliveryText.text = FAILUREMESSAGE;
        animator.SetTrigger(POPUPTRIGGER);

    }

    private void DeliveryManager_OnDeliverySuccess(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        animator.SetTrigger(POPUPTRIGGER);
        backgroundImage.color = successColor;
        iconImage.sprite = successSprite;
        deliveryText.text = SUCCESSFULMESSAGE;
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
