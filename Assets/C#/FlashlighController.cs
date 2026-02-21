using System;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class FlashlighController : MonoBehaviour
{
    public GameObject flashlightVisual;
    public Light flashlightLight;
    private float maxDistance = 1f;
    [SerializeField] private float flashlightIntensity = 2f;
    [SerializeField] private float requiredHoldTime = 3f;

    private INeons currentNeon;
    private float holdTimer;


    private void Start()
    {
        
    }
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
    }
    public void TryToGetNeon()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance) &&
            hit.collider.TryGetComponent<INeons>(out INeons neon))
        {

            neon.ActivateVisual();
            neon.IncreaseEmission();
            if (neon == currentNeon)
            {
                holdTimer += Time.deltaTime;

                if (holdTimer >= requiredHoldTime)
                {
                    neon.AcquireNeon();
                    ResetProgress();
                }
            }
            else
            {
                currentNeon = neon;
                holdTimer = 0f;
            }
        }
        else
        {
            ResetProgress();
        }
    }

    private void ResetProgress()
    {
        holdTimer = 0f;
        if(currentNeon != null)
        {
            currentNeon.ResetActivationAndEmission();
        }
        currentNeon = null;

    }

    public void FlashlightOn()
    {
        flashlightVisual.SetActive(true);
        flashlightLight.intensity = flashlightIntensity;
    }
    public void FlashlightOff()
    {
        flashlightVisual.SetActive(false);
        flashlightLight.intensity = 0f;
    }

    internal void TryToPickUpNeon()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance) &&
            hit.collider.TryGetComponent<INeons>(out INeons neon))
        {
            if (neon.CanPickUp)
            {
                neon.PickUpNeon();
            }
        }
    }
}
