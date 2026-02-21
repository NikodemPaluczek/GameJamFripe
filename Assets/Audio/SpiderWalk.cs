using UnityEngine;
using System.Collections;

public class SpiderWalk : MonoBehaviour
{
    [Header("DŸwiêki i AudioSource")]
    public AudioClip[] sounds;        // Lista dŸwiêków
    public AudioSource audioSource;   // AudioSource do odtwarzania

    [Header("Cooldown")]
    public float cooldown = 3f;       // Czas przerwy po zakoñczeniu dŸwiêku

    private bool isOnCooldown = false;
    private int lastIndex = -1;

    private void Start()
    {
        audioSource.loop = false;

        // Sprawdzenie, czy obiekt ma Rigidbody (wa¿ne dla ruchomych triggerów)
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true;  // nie wp³ywa na fizykê
            rb.useGravity = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            TryPlaySound();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Dodatkowa opcja: jeœli trigger siê porusza, mo¿emy spróbowaæ odpaliæ dŸwiêk
        if (other.transform.root.CompareTag("Player"))
        {
            TryPlaySound();
        }
    }

    private void TryPlaySound()
    {
        // Jeœli ju¿ coœ gra lub trwa cooldown, nic nie rób
        if (audioSource.isPlaying || isOnCooldown)
            return;

        if (sounds.Length == 0)
            return;

        // Losowanie dŸwiêku (nie powtarzamy tego samego pod rz¹d)
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, sounds.Length);
        } while (randomIndex == lastIndex && sounds.Length > 1);

        lastIndex = randomIndex;

        audioSource.clip = sounds[randomIndex];
        audioSource.Play();

        // Startujemy cooldown
        StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        isOnCooldown = true;

        // Czekamy a¿ dŸwiêk siê skoñczy
        yield return new WaitWhile(() => audioSource.isPlaying);

        // Dodatkowe sekundy cooldownu
        yield return new WaitForSeconds(cooldown);

        isOnCooldown = false;
    }
}

