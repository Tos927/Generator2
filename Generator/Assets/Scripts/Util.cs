using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExoProjetGénérateur.Data;

public class Util : MonoBehaviour
{
    private static Util _instance = null;
    public static Util Instance
    {
        get => _instance; 
    }
    private void Awake()
    {
        _instance = this;
    }

    public Stats SetRandomStats(int min, int max)
    {
        Stats statsRandom;

        int[] statsTab = new int[9];

        for (int i = 0; i < statsTab.Length; i++)
        {
            statsTab[i] = Random.Range(min, max + 1);
        }

        statsRandom = new Stats(statsTab[0], statsTab[1], statsTab[2], statsTab[3],
            statsTab[4], statsTab[5], statsTab[6], statsTab[7], statsTab[8]);

        return statsRandom;
    }
}
