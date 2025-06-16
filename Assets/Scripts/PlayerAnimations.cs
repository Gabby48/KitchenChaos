using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Player player;
    private Animator animator;
    private const string IS_WALKING = "IsWalking";
private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
