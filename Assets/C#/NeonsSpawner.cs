using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class NeonsSpawner : MonoBehaviour
{
    [SerializeField] private List<OrangeNeonController> orangeNeons;
    private int orangeActive;
    

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
            Spawn3NeonsAtRandomSpawnpoints();
        }
    }

    private void Spawn3NeonsAtRandomSpawnpoints()
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
}
