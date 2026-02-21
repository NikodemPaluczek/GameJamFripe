using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class NeonsSpawner : MonoBehaviour
{
    public static NeonsSpawner Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private List<OrangeNeonController> orangeNeons;
    [SerializeField] private List<GreenNeonController> greenNeons;
    [SerializeField] private List<PinkNeonController> pinkNeons;

    private int orangeActive;
    private int greenActive;
    private int pinkActive;

    private void Start()
    {
        Spawn3OrangeNeonsAtRandomSpawnpoints();
        Spawn3GreenNeonsAtRandomSpawnpoints();
        Spawn3PinkNeonsAtRandomSpawnpoints();
    }

    public void CheckHowManyOrangeActive()
    {
        orangeActive = 0;
        foreach (OrangeNeonController orangeNeon in orangeNeons)
        {
            if (orangeNeon.gameObject.activeSelf)
            {
                orangeActive++;
            }
        }
        if (orangeActive == 0)
        {
            Spawn3OrangeNeonsAtRandomSpawnpoints();
        }
    }
    public void CheckHowManyGreenActive()
    {
        greenActive = 0;
        foreach (GreenNeonController greenNeon in greenNeons)
        {
            if (greenNeon.gameObject.activeSelf)
            {
                greenActive++;
            }
        }
        if (greenActive == 0)
        {
            Spawn3GreenNeonsAtRandomSpawnpoints();
        }
    }
    public void CheckHowManyPinkActive()
    {
        pinkActive = 0;
        foreach (PinkNeonController pinkNeon in pinkNeons)
        {
            if (pinkNeon.gameObject.activeSelf)
            {
                pinkActive++;
            }
        }
        if (pinkActive == 0)
        {
            Spawn3PinkNeonsAtRandomSpawnpoints();
        }
    }

    private void Spawn3OrangeNeonsAtRandomSpawnpoints()
    {
        
        for (int i = 0; i < 3; i++)
        {
            int randomNumber = Random.Range(0, orangeNeons.Count);
            if (orangeNeons[randomNumber].gameObject.activeSelf)
            {
                i--;
                continue;
            }
            orangeNeons[randomNumber].gameObject.SetActive(true);
            

        }
    }
    private void Spawn3GreenNeonsAtRandomSpawnpoints()
    {

        for (int i = 0; i < 3; i++)
        {
            int randomNumber = Random.Range(0, greenNeons.Count);
            if (greenNeons[randomNumber].gameObject.activeSelf)
            {
                i--;
                continue;
            }
            greenNeons[randomNumber].gameObject.SetActive(true);


        }
    }
    private void Spawn3PinkNeonsAtRandomSpawnpoints()
    {

        for (int i = 0; i < 3; i++)
        {
            int randomNumber = Random.Range(0, pinkNeons.Count);
            if (pinkNeons[randomNumber].gameObject.activeSelf)
            {
                i--;
                continue;
            }
            pinkNeons[randomNumber].gameObject.SetActive(true);


        }
    }
}
