using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour
{
    [SerializeField]
    private AudioClip introClip;
    [SerializeField]
    private AudioClip rockMusicClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Assign the intro clip to the AudioSource
        audioSource.clip = introClip;

        // Start playing the intro clip
        audioSource.Play();

        // Start coroutine to play rock music after intro clip has finished
        StartCoroutine(PlayRockMusicAfterIntro());
    }

    IEnumerator PlayRockMusicAfterIntro()
    {
        // Wait for the duration of the intro clip
        yield return new WaitForSeconds(introClip.length);

        // Assign the rock music clip to the AudioSource
        audioSource.clip = rockMusicClip;

        // Set the audio clip to loop
        audioSource.loop = true;

        // Start playing the rock music
        audioSource.Play();
    }
}
