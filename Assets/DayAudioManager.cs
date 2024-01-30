using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClip;
    [SerializeField] private AudioClip coinIntervalClip;
    [SerializeField] private AudioClip placeObjectClip;
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonClip);
    }

    public void PlayCoinIntervalSound()
    {
        audioSource.PlayOneShot(coinIntervalClip);
    }
    public void PlayPlaceObjectSound()
    {
        audioSource.PlayOneShot(placeObjectClip);
    }
}
