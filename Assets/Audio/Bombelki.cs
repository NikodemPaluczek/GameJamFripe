using UnityEngine;

public class Bombelki : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioSource audioSource;
    public float cooldown = 2f; // Czas przerwy miêdzy dŸwiêkami

    private float lastPlayTime = -Mathf.Infinity;
    private int lastIndex = -1;

    private void Start()
    {
        audioSource.loop = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TryPlaySound();
        }
    }

    void TryPlaySound()
    {
        // Sprawdza czy min¹³ cooldown
        if (Time.time < lastPlayTime + cooldown)
            return;

        if (sounds.Length == 0)
            return;

        int randomIndex;

        // Zapobiega powtórzeniu tego samego dŸwiêku 2x pod rz¹d
        do
        {
            randomIndex = Random.Range(0, sounds.Length);
        }
        while (randomIndex == lastIndex && sounds.Length > 1);

        lastIndex = randomIndex;
        lastPlayTime = Time.time;

        audioSource.clip = sounds[randomIndex];
        audioSource.Play();
    }
}