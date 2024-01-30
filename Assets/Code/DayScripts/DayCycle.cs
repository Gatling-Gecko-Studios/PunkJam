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
    public float lightIntensity;

    private float timer;
    private Light dirLight;

    void Start()
    {
        dirLight = GetComponent<Light>();
        dirLight.intensity = lightIntensity;
        lightPointer.transform.Translate(startPos.position, Space.World);
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.LookAt(lightPointer.transform.position);
        Debug.Log(timer);
        MoveLight();
        ChangeLightColor();
    }

    private void MoveLight()
    {
        transform.position = Vector3.Lerp(startPos.position, endPos.position, (timer / dayLength));
    }

    private void ChangeLightColor()
    {
        dirLight.color = lightGradient.Evaluate(Mathf.Lerp(0, dayLength, timer)).linear;
    }
}
