using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTextManager : MonoBehaviour
{
    public GameObject popupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPopup(float amount)
    {
        if(amount > 0)
        {
            GameObject.FindObjectOfType<DayAudioManager>().PlayCoinIntervalSound();
            GameObject popup = Instantiate(popupPrefab, transform.position, Quaternion.identity);
            popup.GetComponent<PointTextScript>().SetText("+" + amount.ToString());
            popup.GetComponent<TMPro.TextMeshPro>().color = Color.green;
        }
        if(amount < 0)
        {
            GameObject.FindObjectOfType<DayAudioManager>().PlayCoinIntervalSound();
            GameObject popup = Instantiate(popupPrefab, transform.position, Quaternion.identity);
            popup.GetComponent<PointTextScript>().SetText(amount.ToString());
            popup.GetComponent<TMPro.TextMeshPro>().color = Color.red;
        }

    }
}
