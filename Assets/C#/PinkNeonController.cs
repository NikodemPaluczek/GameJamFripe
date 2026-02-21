using UnityEngine;

public class PinkNeonController : MonoBehaviour, INeons
{
    [SerializeField] Material materialForFlashlight;

    [SerializeField] GameObject neonVisual;
    [SerializeField] Renderer visualRenderer;

    private Material mat;
    private float duration = 3f;
    private float elapsedTime = 0f;
    private float targetIntensity = 400f;

    [SerializeField] private float explosionForce = 3f;

    private Vector3 pushAwayDir;

    Color pinkColor = new Color32(229, 0, 207, 255);

    public bool CanPickUp { get; set; }
    public string NeonColor { get; set; }

    private void Start()
    {
        NeonColor = "Pink";
    }
    public void AcquireNeon()
    {
        
        Renderer FlashlightVisualrenderer = FlashlighController.Instance.flashlightVisual.GetComponent<Renderer>();

        FlashlightVisualrenderer.material = materialForFlashlight;

        pushAwayDir = Player.Instance.transform.position - transform.position;

        Player.Instance.transform.position += pushAwayDir * explosionForce;

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
            mat.SetColor("_EmissionColor", pinkColor * intensity);
        }
    }

    public void PickUpNeon()
    {
        gameObject.SetActive(false);
        elapsedTime = 0f;
        neonVisual.SetActive(false);
        ProgressionManager.Instance.updatePinkCounter();
        NeonsSpawner.Instance.CheckHowManyOrangeActive();
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
