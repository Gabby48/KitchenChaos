using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine; 
using UnityEngine.UIElements;

public class Player : MonoBehaviour ,IKitchenObjectParent
{

    public static Player Instance { get; private set; }
    

    [SerializeField] private float movement = 1f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask;
    private bool isWalking;
    [SerializeField] private Transform kitchenObjectHoldPoint;
    [SerializeField] private KitchenObject kitchenObject;
    [SerializeField] private GameHandler gameHandler;


    private Vector3 lastInteractDir;

    private BaseCounter selectedCounter;

    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public event EventHandler OnPickUp;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }

    private void Awake()
    {
        

        if (Instance != null)
        {
            Debug.LogError("THere is more than one player instance");
        }
        Instance = this;
    }
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnInteractAlternateAction += GameInput_OnInteractAlternateAction;

    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (!gameHandler.isGamePlaying()) return;
        
            if (selectedCounter != null)
            {
                selectedCounter.Interact(this);
            }

        
      
        

    }

    private void GameInput_OnInteractAlternateAction(object sender, System.EventArgs e)
    {

        if (!gameHandler.isGamePlaying()) return;

        if (selectedCounter != null)
            {
                selectedCounter.InteractAlternate(this);
            }
        

    }
    // Update is called once per frame
    private void Update()
    {
        HandleMovement();
        HandleInteractions();





    
    }



    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);



        float moveDistance = movement * Time.deltaTime;
        float playerRadius = .7f;


        float playerHeight = 2f;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);


        if (!canMove)
        {
            // Cannot move towards moveDir

            // Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = (moveDir.x < -.5f || moveDir.x > +.5f) && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                // Can move only on the X
                moveDir = moveDirX;
            }
            else
            {
                // Cannot move only on the X

                // Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = (moveDir.z < -.5f || moveDir.z > +.5f) && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    // Can move only on the Z
                    moveDir = moveDirZ;
                }
                else
                {
                    // Cannot move in any direction
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }


        float rotSpeed = 10f;

        isWalking = moveDir != Vector3.zero;


        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotSpeed);


    }

    private void HandleInteractions()
    {

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;

        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {

            if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                if (baseCounter != selectedCounter)
                {


                    SetSelectedCounter(baseCounter);
                    



                }


            }
            else
            {
                SetSelectedCounter(null);
            }


        }
        else
        {

            SetSelectedCounter(null);

        }

    }



    private void SetSelectedCounter(BaseCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = selectedCounter
        });

        
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return kitchenObjectHoldPoint;
    }


    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        if (kitchenObject != null) 
        {
            OnPickUp?.Invoke(this, EventArgs.Empty);
        }
        

    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
