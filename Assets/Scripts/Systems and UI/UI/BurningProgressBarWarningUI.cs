using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningProgressBarWarningUI : MonoBehaviour
{

    [SerializeField] private StoveCounter stoveCounter;

    private const string ISFLASHING = "isFlashing";

    private Animator animator;
    private bool show = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
        show = false;
        
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        float burnShowProgressAmount = 0.5f;

        show = stoveCounter.isBurning() && e.progressNormalized >= burnShowProgressAmount;

        animator.SetBool(ISFLASHING, show);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

   
}
