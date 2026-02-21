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
    [SerializeField] TextMeshProUGUI infoText;
    public void updateOrangeCounter()
    {
        orangeNeonsCounter++;
        math.clamp(orangeNeonsCounter, 0, 5); //we have to gather 5 of each
        infoText.text = $"Orange Counter = {orangeNeonsCounter.ToString()} ";
    }
}
