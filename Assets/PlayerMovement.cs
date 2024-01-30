using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] Transform topDownMovementOrientationRefference;

    private Vector3 moveDirection;
    private Rigidbody rb;
    private Vector2 movementVector;
    private PlayerInputActions playerInputActions;
    private Quaternion startingRotation;

    private void Awake()
    {
        
    }


    void Start()
    {
        startingRotation = transform.rotation;
        playerInputActions = GameManager.Instance.playerInputActions;
        rb = GetComponent<Rigidbody>();

        if(mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    void Update()
    {
        MoveInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void MoveInput()
    {
        // Check if the player is in first-person mode
        if (GameManager.Instance.FPSMode)
        {
            // Read movement input relative to the player's forward and right directions
            movementVector = playerInputActions.Day.Move.ReadValue<Vector2>();
            moveDirection = transform.forward * movementVector.y + transform.right * movementVector.x;
        }
        else
        {
            // Read movement input in world space directions
            movementVector = playerInputActions.Day.Move.ReadValue<Vector2>();
            // In top-down mode, up corresponds to north, so we use world space directions
            moveDirection = topDownMovementOrientationRefference.forward * movementVector.y + topDownMovementOrientationRefference.right * movementVector.x;
        }
    }

    private void Move()
    {
        rb.AddForce(moveDirection * moveSpeed);
    }


}
