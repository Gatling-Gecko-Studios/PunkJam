using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTextScript : MonoBehaviour
{
    private GameObject mainCamera;
    private float timer;
    public float goneTime;
    public AnimationCurve curve;
    private Vector3 startScale;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameManager.Instance.mainCamera;
        startScale = transform.localScale;
        //SetText("+1000");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(mainCamera.transform);
        timer += Time.deltaTime;

        transform.localScale = startScale * curve.Evaluate(timer / goneTime);
    }

    public void SetText(string text)
    {
        GetComponent<TMPro.TextMeshPro>().text = text;
    }
}
