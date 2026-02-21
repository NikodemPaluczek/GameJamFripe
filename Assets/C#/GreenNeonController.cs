using UnityEngine;

public class GreenNeonController : MonoBehaviour, INeons
{
    [SerializeField] Material materialForFlashlight;

    [SerializeField] GameObject neonVisual;
    [SerializeField] Renderer visualRenderer;

    private Material mat;
    private float duration = 3f;
    private float elapsedTime = 0f;
    private float targetIntensity = 400f;


    Color greenColor = new Color(0.2196f, 0.8980f, 0f);
    public bool CanPickUp { get ; set ; }
    public string NeonColor { get; set; }

    private void Start()
    {
        NeonColor = "Green";
    }
    public void AcquireNeon()
    {
        Renderer FlashlightVisualrenderer = FlashlighController.Instance.flashlightVisual.GetComponent<Renderer>();

        FlashlightVisualrenderer.material = materialForFlashlight;
        CanPickUp = true;

    }

    public void ActivateVisual()
    {
        neonVisual.SetActive(true);
    }

    public void IncreaseEmission()
    {
        mat = visualRenderer.material;
        mat.EnableKeyword("_EMISSION");
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float intensity = Mathf.Lerp(0f, targetIntensity, elapsedTime / duration);
            mat.SetColor("_EmissionColor", greenColor * intensity);
        }
    }

    public void PickUpNeon()
    {
        gameObject.SetActive(false);
        elapsedTime = 0f;
        neonVisual.SetActive(false);
        ProgressionManager.Instance.updateGreenCounter();
        NeonsSpawner.Instance.CheckHowManyGreenActive();
        CanPickUp = false;
    }

    public void ResetActivationAndEmission()
    {
        if (!CanPickUp)
        {
            elapsedTime = 0f;
            neonVisual.SetActive(false);
        }

    }
}
