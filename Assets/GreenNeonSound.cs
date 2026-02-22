using UnityEngine;

public class GreenNeonSound : MonoBehaviour
{
    public static GreenNeonSound Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
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
