using TMPro;
using Unity.Mathematics;
using UnityEngine;

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

    [SerializeField] TextMeshProUGUI infoTextOrange;
    [SerializeField] TextMeshProUGUI infoTextGreen;
    [SerializeField] TextMeshProUGUI infoTextPink;
    public void updateOrangeCounter()
    {
        orangeNeonsCounter++;
        math.clamp(orangeNeonsCounter, 0, 5); //we have to gather 5 of each
        infoTextOrange.text = $"Orange Counter = {orangeNeonsCounter.ToString()} ";
    }
    public void updateGreenCounter()
    {
        greenNeonsCounter++;
        math.clamp(greenNeonsCounter, 0, 5); //we have to gather 5 of each
        infoTextGreen.text = $"Green Counter = {greenNeonsCounter.ToString()} ";
    }
    public void updatePinkCounter()
    {
        pinkNeonsCounter++;
        math.clamp(pinkNeonsCounter, 0, 5); //we have to gather 5 of each
        infoTextPink.text = $"Pink Counter = {pinkNeonsCounter.ToString()} ";
    }
}
