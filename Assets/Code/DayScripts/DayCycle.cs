using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class DayCycle : MonoBehaviour
{
    [Header("Day cycle values")]
    public Gradient lightGradient;
    public GameObject lightPointer;
    public Transform startPos;
    public Transform endPos;
    public float dayLength;
    public float minLightIntensity;
    public float maxLightIntensity;

    private float timer;
    private Light dirLight;

    void Start()
    {
        dirLight = GetComponent<Light>();
        dirLight.intensity = minLightIntensity;
        lightPointer.transform.Translate(startPos.position, Space.World);
    }

    void Update()
    {
        timer = GameManager.Instance.timer;
        transform.LookAt(lightPointer.transform.position);
        MoveLight();
        ChangeLightColor();
        ChangeLightIntensity();
    }

    private void MoveLight()
    {
        transform.position = Vector3.Lerp(startPos.position, endPos.position, (timer / dayLength));
    }

    private void ChangeLightColor()
    {
        dirLight.color = lightGradient.Evaluate(Mathf.Lerp(0, dayLength, timer)).linear;
    }

    private void ChangeLightIntensity()
    {
        if (timer > 0 && timer <= 90)
        {
            // Interpolate intensity from 1 to 2 during the first half of the day
            dirLight.intensity = Mathf.Lerp(minLightIntensity, maxLightIntensity, timer / 90f);
        }
        else if (timer > 90 && timer <= 180)
        {
            // Interpolate intensity from 2 to 1 during the second half of the day
            dirLight.intensity = Mathf.Lerp(maxLightIntensity, minLightIntensity, (timer - 90f) / 90f);
        }

    }
}
