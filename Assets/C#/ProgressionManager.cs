using System;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionManager : MonoBehaviour
{
    public static ProgressionManager Instance { get; private set; }

    [SerializeField] private GameObject[] teleports;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public int orangeNeonsCounter = 0;
    private int greenNeonsCounter = 0;
    private int pinkNeonsCounter = 0;

    [SerializeField] Image orangeCounter;
    [SerializeField] Image pinkCounter;
    [SerializeField] Image greenCounter;

    [SerializeField] Sprite[] orangeCounterSprites;
    [SerializeField] Sprite[] pinkCounterSprites;
    [SerializeField] Sprite[] greenCounterSprites;

    [SerializeField] GameObject boulder;
    public void updateOrangeCounter(int amount)
    {
        orangeNeonsCounter += amount;
        math.clamp(orangeNeonsCounter, 0, 5); //we have to gather 5 of each
        if(orangeNeonsCounter == 5)
        {
            OpenOrangeTeleports();
            CheckIfWeHaveItAll();
        }
        orangeCounter.sprite = orangeCounterSprites[orangeNeonsCounter];
    }

    private void OpenOrangeTeleports()
    {
        foreach (GameObject teleport in teleports)
        {
            teleport.SetActive(true);
        }
    }

    public void updateGreenCounter()
    {
        greenNeonsCounter++;
        math.clamp(greenNeonsCounter, 0, 5); //we have to gather 5 of each
        if (greenNeonsCounter == 5)
        {
            UpgradeHealth();
            CheckIfWeHaveItAll();
        }
        greenCounter.sprite = greenCounterSprites[greenNeonsCounter];
    }

    private void UpgradeHealth()
    {
        Player.Instance.canHave4Hearts = true;
        Player.Instance.UpdateHealth(4);
    }

    public void updatePinkCounter()
    {
        pinkNeonsCounter++;
        math.clamp(pinkNeonsCounter, 0, 5); //we have to gather 5 of each
        pinkCounter.sprite = pinkCounterSprites[pinkNeonsCounter];
        CheckIfWeHaveItAll();
    }

    private void CheckIfWeHaveItAll()
    {
        
        if(orangeNeonsCounter == 5 && pinkNeonsCounter ==5 && greenNeonsCounter == 5)
        {
            boulder.SetActive(false);
        }
    }
}
