using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionManager : MonoBehaviour
{
    public static ProgressionManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private int orangeNeonsCounter = 0;
    private int greenNeonsCounter = 0;
    private int pinkNeonsCounter = 0;

    [SerializeField] Image orangeCounter;
    [SerializeField] Image pinkCounter;
    [SerializeField] Image greenCounter;

    [SerializeField] Sprite[] orangeCounterSprites;
    [SerializeField] Sprite[] pinkCounterSprites;
    [SerializeField] Sprite[] greenCounterSprites;
    public void updateOrangeCounter()
    {
        orangeNeonsCounter++;
        math.clamp(orangeNeonsCounter, 0, 5); //we have to gather 5 of each
        orangeCounter.sprite = orangeCounterSprites[orangeNeonsCounter];
    }
    public void updateGreenCounter()
    {
        greenNeonsCounter++;
        math.clamp(greenNeonsCounter, 0, 5); //we have to gather 5 of each
        greenCounter.sprite = greenCounterSprites[greenNeonsCounter];
    }
    public void updatePinkCounter()
    {
        pinkNeonsCounter++;
        math.clamp(pinkNeonsCounter, 0, 5); //we have to gather 5 of each
        pinkCounter.sprite = pinkCounterSprites[pinkNeonsCounter];
    }
}
