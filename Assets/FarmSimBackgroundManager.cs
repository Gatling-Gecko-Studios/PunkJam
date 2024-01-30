using UnityEngine;

public class FarmSimBackgroundManager : MonoBehaviour
{
    [SerializeField] private AudioClip dayBackgroundClip;
    [SerializeField] private AudioClip daySwitchClip;
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDayBackgroundMusic()
    {
        audioSource.clip = dayBackgroundClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayTransitionMusic()
    {
        audioSource.clip = daySwitchClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
