
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image barImage;

    private IHasProgress progressor;

    // Start is called before the first frame update
    void Start()
    {
        progressor = hasProgressGameObject.GetComponent<IHasProgress>();


        if (progressor == null)
        {
            Debug.LogError("GameObject" + hasProgressGameObject + "does not match the setup");
        }
        

        
        progressor.OnProgressChanged += progressor_OnProgressChanged;
        barImage.fillAmount = 0f;

        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void progressor_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;

        if(e.progressNormalized == 1f)
        {
            Hide();
        }
        else
        {
            Show();
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
