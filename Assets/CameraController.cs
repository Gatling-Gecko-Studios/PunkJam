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
                transform.parent = null;
                FPSMode = false;
                transform.position = managementCameraPosition;
                transform.rotation = managementCameraRotation;
                mainCamera.orthographic = true;
                Cursor.lockState = CursorLockMode.None;

}
            else
            {
                Debug.Log("changed to perspective");
                FPSMode = true;
                mainCamera.orthographic = false;
                transform.position = FPSCameraPoint.position;
                transform.parent = FPSCameraPoint;
                transform.rotation = Quaternion.LookRotation(FPSCameraPoint.right);
                Cursor.lockState = CursorLockMode.Locked;

            }
        }

        if (FPSMode)
        {
            Look();
        }
    }

    private void Look()
    {
        // Get the mouse input from the Input Actions
        Vector2 mouseInput = playerInputActions.Night.Look.ReadValue<Vector2>();

        // Calculate the camera rotation
        xRotation -= mouseInput.y * sens;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f); // Clamp to prevent over-rotation

        yRotation += mouseInput.x * sens;

        // Apply rotation to the orientation and the camera
        player.transform.localRotation = Quaternion.Euler(0.0f, yRotation, 0f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
