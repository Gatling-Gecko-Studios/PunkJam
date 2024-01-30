using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Camera mainCamera;
    private Vector3 managementCameraPosition;
    private Quaternion managementCameraRotation;
    [SerializeField] Transform FPSCameraPoint;
    [SerializeField] float sens = 2f;
    private PlayerInputActions playerInputActions;
    public bool FPSMode;

    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private float currentXRotation = 0f;

    private float minYRotation = -90f;
    private float maxYRotation = 90f;

    void Start()
    {
        playerInputActions = GameManager.Instance.playerInputActions;
        managementCameraPosition = transform.position;
        managementCameraRotation = transform.rotation;
        mainCamera = GetComponent<Camera>();
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }


    void Update()
    {
        
        if (playerInputActions.Day.TogglePerspective.triggered)
        {
            Debug.Log("Change perspective!");
            xRotation = 0.0f;
            yRotation = 0.0f;
            if (FPSMode)
            {
                Debug.Log("changed to ortho");
                FPSMode = false;
                player.GetComponent<PlayerMovement>().SetFPSMode(false);
                transform.position = managementCameraPosition;
                transform.rotation = managementCameraRotation;
                mainCamera.orthographic = true;
                Cursor.lockState = CursorLockMode.None;


}
            else
            {
                Debug.Log("changed to perspective");
                FPSMode = true;
                player.GetComponent<PlayerMovement>().SetFPSMode(true);
                mainCamera.orthographic = false;
                transform.position = FPSCameraPoint.position;
                //transform.rotation = Quaternion.LookRotation(FPSCameraPoint.forward); 

                Cursor.lockState = CursorLockMode.Locked;

            }
        }

        if (FPSMode)
        {
            transform.position = FPSCameraPoint.position;
            Look();
        }
    }

    private void Look()
    {
        // Get the mouse input from the Input Actions
        Vector2 mouseDelta= playerInputActions.Night.Look.ReadValue<Vector2>();
        RotatePlayer(mouseDelta);

        // Calculate the camera rotation
        //xRotation -= mouseInput.y * sens;
        //xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f); // Clamp to prevent over-rotation

        //yRotation += mouseInput.x * sens;

        //// Apply rotation to the orientation and the camera
        //player.transform.rotation = Quaternion.Euler(0.0f, yRotation, 0f);
        //transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    private void RotatePlayer(Vector2 mouseDelta)
    {
        // Adjust the rotation based on mouse movement
        float mouseX = mouseDelta.x * sens;
        float mouseY = mouseDelta.y * sens;

        // Update the current X rotation
        currentXRotation -= mouseY;
        // Clamp the rotation to avoid flipping
        currentXRotation = Mathf.Clamp(currentXRotation, minYRotation, maxYRotation);

        // Rotate the player around the Y-axis (horizontal movement)
        transform.Rotate(Vector3.up, mouseX, Space.World);

        player.transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f); //only rotate y axis of player

        // Rotate the player around the local X-axis (vertical movement)
        transform.localRotation = Quaternion.Euler(currentXRotation, transform.localEulerAngles.y, 0f);
    }
}
