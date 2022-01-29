using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExoProjetGénérateur.Data;
using System.Linq;

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

    public Stats SetRandomStats(int min, int max, int howManyStats)
    {
        Stats statsRandom;

        int nbrStatsInGame = 9;

        int[] statsTab = new int[nbrStatsInGame];

        for (int i = 0; i < statsTab.Length; i++)
        {
            statsTab[i] = 0;
        }

        int[] choice = new int[howManyStats];

        for (int i = 0; i < choice.Length; i++)
        {
            choice[i] = -1;
            int randomChoice = Random.Range(0, nbrStatsInGame);

            choice[i] = NewNumber(choice, i, randomChoice);

            statsTab[choice[i]] = Random.Range(min, max + 1);
        }

        statsRandom = new Stats(statsTab[0], statsTab[1], statsTab[2], statsTab[3],
            statsTab[4], statsTab[5], statsTab[6], statsTab[7], statsTab[8]);

        return statsRandom;
    }

    public int NewNumber(int[] tab, int i, int random)
    {
        int nbr = 0;

        if (!tab.Contains(random))
        {
            //tab[i] = random;

            nbr = random;
        }
        else
        {
            random = Random.Range(0, 9);

            nbr = NewNumber(tab, i, random);
        }

        return nbr;
    }
}