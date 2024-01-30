using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float secondsToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestoryAfterSecs(secondsToDestroy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DestoryAfterSecs(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
