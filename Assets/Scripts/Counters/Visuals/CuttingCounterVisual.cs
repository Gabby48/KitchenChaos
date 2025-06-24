using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{

    [SerializeField] private CuttingCounter cuttingCounter;

    private Animator animator;

    private const string Cut = "Cut";
    


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        cuttingCounter.OnCut += CuttingCounter_OnCutObject;
        
    }


    private void CuttingCounter_OnCutObject(object sender, System.EventArgs e)
    {
        animator.SetTrigger(Cut);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
