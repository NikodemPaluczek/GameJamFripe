using NUnit.Framework;
using UnityEngine;

public class OrangeNeonController : MonoBehaviour, INeons
{


    [SerializeField] Material materialForFlashlight;

    [SerializeField] GameObject neonVisual;
    [SerializeField] Renderer visualRenderer;

    private Material mat;
    private float duration = 3f;
    private float elapsedTime = 0f;
    private float targetIntensity = 400f;
    

    Color orangeColor = new Color(254f / 255f, 134f / 255f, 22f / 255f);



    public bool CanPickUp { get ; set; }
    public string NeonColor { get; set; }

    private void Start()
    {
        NeonColor = "Orange";
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
            mat.SetColor("_EmissionColor", orangeColor * intensity);
        }
    }

    public void ResetActivationAndEmission()
    {
        if (!CanPickUp)
        {
            elapsedTime = 0f;
            neonVisual.SetActive(false);
        }

    }

    public void PickUpNeon()
    {
        gameObject.SetActive(false);
        elapsedTime = 0f;
        neonVisual.SetActive(true);
        ProgressionManager.Instance.updateOrangeCounter();
        NeonsSpawner.Instance.CheckHowManyOrangeActive();

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            
        }
    }

}
