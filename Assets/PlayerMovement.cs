using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] float moveSpeed = 10f;
    private bool FPSMode;

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
        movementVector = playerInputActions.Day.Move.ReadValue<Vector2>();

        moveDirection = transform.forward * -movementVector.x + transform.right * movementVector.y;
    }

    private void Move()
    {
        rb.AddForce(moveDirection * moveSpeed);
    }

    public void SetFPSMode(bool value)
    {
        FPSMode = value;
        transform.rotation = startingRotation;
    }

}
