using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystemTestScript : MonoBehaviour
{
    PlayerInputActions playerInputActions; //bruh
    public Vector2 movement;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = playerInputActions.Day.Move.ReadValue<Vector2>();

        if (playerInputActions.Day.Interact.triggered)
        {
            Debug.Log("interact button pressed");
        }
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }
}
