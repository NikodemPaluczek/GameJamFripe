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

    public Light flashlightLight;
    private float maxDistance = 3f;
    [SerializeField] private float flashlightIntensity = 36.5f;
    [SerializeField] private float requiredHoldTime = 3f;


    private INeons currentNeon;
    private float holdTimer;

    [SerializeField] private Material startMat;
    
    private Color startColor;

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
        startColor = flashlightLight.color;
        FlashlightOff();
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

        float timer = 0f;

        while (timer < 2f)
        {
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            {
                Enemy enemy = hit.collider.GetComponentInParent<Enemy>();
                if (enemy != null)
                {
                    enemy.StartCoroutine(enemy.OrangeAttack());
                    FlashlightOff();
                    currentActiveNeon = ActiveNeon.None;
                    flashlightLight.color = startColor;
                    yield break;
                }
            }

            timer += Time.deltaTime;
            yield return null; 
        }

        FlashlightOff();
        currentActiveNeon = ActiveNeon.None;
        flashlightLight.color = startColor;
    }

    IEnumerator UseGreenAbility()
    {
        FlashlightOn();

        float timer = 0f;

        while (timer < 2f)
        {
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            {
                Enemy enemy = hit.collider.GetComponentInParent<Enemy>();
                if (enemy != null)
                {
                    enemy.StartCoroutine(enemy.GreenAttack());
                    FlashlightOff();
                    currentActiveNeon = ActiveNeon.None;
                    flashlightLight.color = startColor;
                    yield break;
                }
            }

            timer += Time.deltaTime;
            yield return null;
        }

        FlashlightOff();
        currentActiveNeon = ActiveNeon.None;
        flashlightLight.color = startColor;
    }
    IEnumerator UsePinkAbility()
    {
        FlashlightOn();

        float timer = 0f;

        while (timer < 2f)
        {
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            {
                Enemy enemy = hit.collider.GetComponentInParent<Enemy>();
                if (enemy != null)
                {
                    enemy.StartCoroutine(enemy.PinkAttack());
                    FlashlightOff();
                    currentActiveNeon = ActiveNeon.None;
                    flashlightLight.color = startColor;
                    yield break;
                }
            }

            timer += Time.deltaTime;
            yield return null;
        }

        FlashlightOff();
        currentActiveNeon = ActiveNeon.None;
        flashlightLight.color = startColor;
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
        flashlightLight.intensity = flashlightIntensity;
    }
    public void FlashlightOff()
    {
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
