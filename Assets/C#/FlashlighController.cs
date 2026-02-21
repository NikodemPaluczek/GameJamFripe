using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class FlashlighController : MonoBehaviour
{
    public static FlashlighController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public GameObject flashlightVisual;
    public Light flashlightLight;
    private float maxDistance = 1f;
    [SerializeField] private float flashlightIntensity = 2f;
    [SerializeField] private float requiredHoldTime = 3f;

    Renderer visualRenderer;

    private INeons currentNeon;
    private float holdTimer;

    [SerializeField] private Material startMat;

    private enum ActiveNeon
    {
        None,
        Orange,
        Green,
        Pink
    }
    private ActiveNeon currentActiveNeon = ActiveNeon.None;


    private void Start()
    {
        visualRenderer = flashlightVisual.GetComponent<Renderer>();
        startMat = visualRenderer.material;
    }
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
    }
    public void TryToGetNeon()
    {
        if (currentActiveNeon == ActiveNeon.None)
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
                        FlashlightOff();
                        ResetProgress();
                        if (neon.NeonColor == "Orange")
                        {
                            currentActiveNeon = ActiveNeon.Orange;
                        }
                        else if(neon.NeonColor == "Green")
                        {
                            currentActiveNeon = ActiveNeon.Green;
                        }
                        else if(neon.NeonColor == "Pink")
                        {
                            currentActiveNeon = ActiveNeon.Pink;
                        }
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
        else if (currentActiveNeon == ActiveNeon.Orange && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(UseOrangeAbility());
        }
        else if (currentActiveNeon == ActiveNeon.Green && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(UseGreenAbility());
        }
        else if (currentActiveNeon == ActiveNeon.Pink && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("powinno zaczynac korutyne");
            StartCoroutine(UsePinkAbility());
        }
        else
        {
            Debug.Log("enum currentactive nawalil");
        }
    }

    IEnumerator UseOrangeAbility()
    {
        FlashlightOn();
        Ray ray = new Ray(transform.position, transform.forward);


        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("enemy hit");
                StartCoroutine(enemy.OrangeAttack());
            }
        }
        yield return new WaitForSeconds(1f);
        FlashlightOff();
        currentActiveNeon = ActiveNeon.None;
        visualRenderer.material = startMat;


    }

    IEnumerator UseGreenAbility()
    {
        FlashlightOn();
        Ray ray = new Ray(transform.position, transform.forward);


        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("enemy hit");
                StartCoroutine(enemy.GreenAttack());
            }
        }
        yield return new WaitForSeconds(1f);
        FlashlightOff();
        currentActiveNeon = ActiveNeon.None;
        visualRenderer.material = startMat;


    }
    IEnumerator UsePinkAbility()
    {
        FlashlightOn();
        Ray ray = new Ray(transform.position, transform.forward);


        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("enemy hit with pink");
                StartCoroutine(enemy.PinkAttack());
            }
        }
        yield return new WaitForSeconds(1f);
        FlashlightOff();
        currentActiveNeon = ActiveNeon.None;
        visualRenderer.material = startMat;


    }

    public void ResetProgress()
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
