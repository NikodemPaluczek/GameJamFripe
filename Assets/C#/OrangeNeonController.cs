using NUnit.Framework;
using UnityEngine;

public class OrangeNeonController : MonoBehaviour, INeons
{
    [SerializeField] FlashlighController flashlighController;
    [SerializeField] Material materialForFlashlight;

    [SerializeField] GameObject neonVisual;
    [SerializeField] Renderer visualRenderer;
    [SerializeField] float emissionIntenisty = 5f;

    private Material mat;
    private float duration = 3f;
    private float elapsedTime = 0f;
    private float targetIntensity = 400f;

    Color orangeColor = new Color(254f / 255f, 134f / 255f, 22f / 255f);

    public void AcquireNeon()
    {
        Renderer FlashlightVisualrenderer = flashlighController.flashlightVisual.GetComponent<Renderer>();

        FlashlightVisualrenderer.material = materialForFlashlight;
        Destroy(gameObject);
    }

    public void ActivateVisual()
    {
        neonVisual.SetActive(true);
    }

    public void IncreaseEmission()
    {
        mat = visualRenderer.material;
        mat.EnableKeyword("_EMISSION");
        Color baseColor = orangeColor;
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float intensity = Mathf.Lerp(0f, targetIntensity, elapsedTime / duration);
            mat.SetColor("_EmissionColor", baseColor * intensity);
        }
    }
        

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            
        }
    }

}
