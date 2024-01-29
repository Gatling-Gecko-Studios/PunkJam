using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] float moveSpeed = 10f;
    public bool FPSMode;

    private Vector3 moveDirection;
    private Rigidbody rb;
    private Vector2 movementVector;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        
    }


    void Start()
    {
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

}
