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
        Spawn7OrangeNeonsAtRandomSpawnpoints();
        Spawn7GreenNeonsAtRandomSpawnpoints();
        Spawn7PinkNeonsAtRandomSpawnpoints();
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
            Spawn7OrangeNeonsAtRandomSpawnpoints();
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
            Spawn7GreenNeonsAtRandomSpawnpoints();
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
            Spawn7PinkNeonsAtRandomSpawnpoints();
        }
    }

    private void Spawn7OrangeNeonsAtRandomSpawnpoints()
    {
        
        for (int i = 0; i < 7; i++)
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
    private void Spawn7GreenNeonsAtRandomSpawnpoints()
    {

        for (int i = 0; i < 7; i++)
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
    private void Spawn7PinkNeonsAtRandomSpawnpoints()
    {

        for (int i = 0; i < 7; i++)
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
