using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
    private int orangeNeonsCounter = 0;
    [SerializeField] TextMeshProUGUI infoText;
    public void updateOrangeCounter()
    {
        orangeNeonsCounter++;
        math.clamp(orangeNeonsCounter, 0, 5); //we have to gather 5 of each
        infoText.text = $"Orange Counter = {orangeNeonsCounter.ToString()} ";
    }
}
