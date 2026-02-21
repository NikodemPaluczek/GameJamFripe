using UnityEngine;
using System.Collections;

public class UV : MonoBehaviour
{
    public AudioSource pulsingLight;
    public float fadeDuration = 0.5f; // Czas wyciszania w sekundach

    private float startVolume;
    private Coroutine fadeCoroutine;

    void Start()
    {
        startVolume = pulsingLight.volume;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (fadeCoroutine != null)
                StopCoroutine(fadeCoroutine);

            pulsingLight.volume = startVolume;
            pulsingLight.Play();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            fadeCoroutine = StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            pulsingLight.volume = Mathf.Lerp(startVolume, 0f, currentTime / fadeDuration);
            yield return null;
        }

        pulsingLight.Stop();
        pulsingLight.volume = startVolume; // Reset g³oœnoœci
    }
}
