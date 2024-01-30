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
    public Transform FPSCameraPoint;
    [SerializeField] float sens = 2f;
    private PlayerInputActions playerInputActions;
    public bool FPSMode;
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
            if (GameManager.Instance.GetFPSMode())
            {
                Debug.Log("changed to ortho");
                FPSMode = false;
                GameManager.Instance.SetFPSMode(false);
                transform.position = managementCameraPosition;
                transform.rotation = managementCameraRotation;
                mainCamera.orthographic = true;
                Cursor.lockState = CursorLockMode.None;


}
            else
            {
                ChangeToFPS();
            }
        }


        if (GameManager.Instance.GetFPSMode())
        {
            transform.position = FPSCameraPoint.position;
            Look();
        }
    }


    public void ChangeToFPS()
    {
        Debug.Log("Changed to perspective");
        StartCoroutine(TransitionToFPS());
    }

    private IEnumerator TransitionToFPS()
    {
        // Save initial position and rotation
        Vector3 initialPosition = transform.position;
        Quaternion initialRotation = transform.rotation;

        // Calculate target position and rotation
        Vector3 targetPosition = FPSCameraPoint.position;
        Quaternion targetRotation = Quaternion.LookRotation(FPSCameraPoint.forward);

        // Time elapsed during the transition
        float elapsedTime = 0f;

        if (mainCamera != null)
        {
            mainCamera.orthographic = false;
        }

        // Perform transition
        while (elapsedTime < 1f)
        {
            // Calculate interpolation factor
            float t = elapsedTime / 1f;

            // Lerp position and rotation
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, t);

            // Update elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        FPSMode = true;
        GameManager.Instance.SetFPSMode(true);

        // Ensure final position and rotation
        transform.position = FPSCameraPoint.position;
        transform.rotation = Quaternion.LookRotation(FPSCameraPoint.forward);

        // Set camera orthographic mode to false


        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Look()
    {
        // Get the mouse input from the Input Actions
        Vector2 mouseDelta= playerInputActions.Night.Look.ReadValue<Vector2>();
        RotatePlayer(mouseDelta);
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
