using Code.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float rotationDuration;
    public int shotDamage = 20;
    public float shotForce = 20f;
    public LayerMask hittableLayers;
    private PlayerInputActions playerInputActions;
    private SwayAndBob swayAndBob;
    private int maxClipSize = 2;
    private int currentLoadedBullets = 2;
    private GameObject weaponHolder;
    private Shake shakeScript;
    private GameObject mainCamera;
    private bool isReloading;


    [Tooltip("how much the z axis gets moved back when shooting. -1 is quite a lot, -2 is maybe too much")]
    [SerializeField] float gunRecoilOffset;
    void Start()
    {
        mainCamera = GameManager.Instance.mainCamera;
        weaponHolder = transform.parent.gameObject;
        playerInputActions = GameManager.Instance.playerInputActions;
        swayAndBob = FindObjectOfType<SwayAndBob>(); //assuming there is only 1 swayandbob script in the scene
        shakeScript = FindObjectOfType<Shake>();
    }

    private void Update()
    {
        ShootInput();
        ReloadInput();
    }

    void ShootInput()
    {
        if(playerInputActions.Night.Shoot.triggered)
        {
            if (currentLoadedBullets == 0 || isReloading) return;
            Shoot();
        }
    }

    void ReloadInput()
    {
        if(playerInputActions.Night.Reload.triggered && !isReloading && currentLoadedBullets < maxClipSize)
        {
            Reload();
        }
    }

    void Shoot()
    {
        //animation
        swayAndBob.StartGunRecoil(gunRecoilOffset);



        //shoot pellets

        //manage dealing damage within pellets
        RaycastShoot();

        //sound

        //camera shake
        shakeScript.StartShake();

        //use ammo (1 of 2 shots)
        currentLoadedBullets -= 1;

        if(currentLoadedBullets <= 0)
        {
            //TODO: add small delay here, where during you also can't reload manually

            Reload();
        }


    }

    private void RaycastShoot()
    {
        if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out RaycastHit hit, 300f, hittableLayers))
        {
            Debug.DrawLine(mainCamera.transform.position, hit.point, Color.green, 2f);
            if(hit.collider.gameObject.TryGetComponent(out SimpleEnemyScript enemyScript))
            {
                Debug.Log("Deal damage");
                enemyScript.TakeDamage(shotDamage, mainCamera.transform.forward);
            }

            if(hit.collider.gameObject.TryGetComponent(out Rigidbody enemyRb))
            {
                Debug.Log("HIT RB");
                enemyRb.AddForce(shotForce * mainCamera.transform.forward, ForceMode.Impulse);
            }
        }
    }

    private void Reload()
    {
        isReloading = true;
        Vector3[] axisArray = {
            Vector3.up,
            Vector3.forward,
            Vector3.right,
        };

        // Generate a random axis for rotation
        Vector3 randomAxis = axisArray[Random.Range(0,3)];

        // Calculate the rotation amount based on time
        float rotationAmount = 360f;

        // Calculate the rotation speed based on the duration
        float rotationSpeed = rotationAmount / rotationDuration;

        //TODO: play sound

        // Start rotating the weaponHolder around the random axis
        StartCoroutine(RotateOverTime(rotationDuration));
    }

    private IEnumerator RotateOverTime(float duration)
    {
        float elapsedTime = 0f;
        Quaternion startRotation = weaponHolder.transform.localRotation;

        // Choose which axis to rotate around randomly
        int axisIndex = Random.Range(0, 3);
        Vector3 targetEulerAngles = startRotation.eulerAngles;

        switch (axisIndex)
        {
            case 0: // Rotate around X-axis
                targetEulerAngles.x -= 360f;
                break;
            case 1: // Rotate around Y-axis
                targetEulerAngles.y += 360f;
                break;
            case 2: // Rotate around Z-axis
                targetEulerAngles.z += 360f;
                break;
        }

        while (elapsedTime < duration)
        {
            // Calculate the interpolation factor
            float t = elapsedTime / duration;

            // Interpolate between the start and target Euler angles
            Vector3 lerpedEulerAngles = Vector3.Lerp(startRotation.eulerAngles, targetEulerAngles, t);

            // Apply the interpolated Euler angles to the rotation
            weaponHolder.transform.localRotation = Quaternion.Euler(lerpedEulerAngles);

            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the rotation finishes exactly at 360 degrees
        weaponHolder.transform.localRotation = Quaternion.Euler(targetEulerAngles);
        RestockAmmo();
        isReloading = false;
    }

    private void RestockAmmo()
    {
        currentLoadedBullets = maxClipSize;
    }
}
