using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private Transform defaultCamTransform;
    private Coroutine currentShake;
    public bool testShakeButton;
    public AnimationCurve shakeCurve;
    public float shakeDuration;
    // Start is called before the first frame update
    void Start()
    {
        defaultCamTransform = FindObjectOfType<CameraController>().FPSCameraPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if(testShakeButton)
        {
            testShakeButton = false;
            StartShake(shakeCurve, 1f, shakeDuration);
        }
    }

    public void StartShake(AnimationCurve curve, float intensityMultiplier, float duration)
    {
        transform.localPosition = defaultCamTransform.position;
        if (currentShake != null)
        {
            transform.localPosition = defaultCamTransform.position;
            StopCoroutine(currentShake);
        }
        currentShake = StartCoroutine(ShakeCam(curve, intensityMultiplier, duration));
    }

    public void StartShake()
    {
        StartShake(shakeCurve, 1f, shakeDuration);
    }

    private IEnumerator ShakeCam(AnimationCurve shakeCurve, float intensityMultiplier, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            float strength = shakeCurve.Evaluate(elapsedTime / duration);
            transform.localPosition = defaultCamTransform.position + Random.insideUnitSphere * strength * intensityMultiplier;
            yield return null;
        }

        transform.localPosition = defaultCamTransform.position;
    }
}
