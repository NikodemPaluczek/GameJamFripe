using UnityEngine;

public class SpiderDeathForSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private AudioSource audioSource;

    public void PlaySound()
    {
        if (sounds.Length == 0) return;

        AudioClip randomClip = sounds[Random.Range(0, sounds.Length)];
        audioSource.PlayOneShot(randomClip);
        Debug.Log("zagral dzwiek" + randomClip);
    }
}