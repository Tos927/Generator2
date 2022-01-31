using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExoProjetGénérateur.Data;
using System.Linq;

public class Util : MonoBehaviour
{
    [SerializeField]
    private GameObject Inventory;

    private static Util _instance = null;
    public static Util Instance
    {
        get => _instance;
    }
    private void Awake()
    {
        _instance = this;

        Inventory.SetActive(false); 
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

            choice[i] = NewNumber(choice, i, randomChoice, 0, 9);

            statsTab[choice[i]] = Random.Range(min, max + 1);
        }

        statsRandom = new Stats(statsTab[0], statsTab[1], statsTab[2], statsTab[3],
            statsTab[4], statsTab[5], statsTab[6], statsTab[7], statsTab[8]);

        return statsRandom;
    }

    public int NewNumber(int[] tab, int i, int random, int newMin, int newMax)
    {
        int nbr = 0;

        if (!tab.Contains(random))
        {
            //tab[i] = random;

            nbr = random;
        }
        else
        {
            random = Random.Range(newMin, newMax);

            nbr = NewNumber(tab, i, random, newMin, newMax);
        }

        return nbr;
    }

    public void DisplayTheGeneration<T>(GameObject[] slot, int i, int child1, int child2, int child3, T myGeneration,
        System.Func<Characters, string> myFunction, System.Func<Equipments, string> myFunction2 = null)
    {
        if (myGeneration is Characters c)
        {
            slot[i].transform.GetChild(child1).GetComponentInChildren<Image>().sprite = c.sprite;

            slot[i].transform.GetChild(child2).GetComponentInChildren<Text>().text = c.name;

            slot[i].transform.GetChild(child3).GetComponentInChildren<Text>().text = myFunction(c);
        }
        else if (myGeneration is Equipments e)
        {
            slot[i].transform.GetChild(child1).GetComponentInChildren<Image>().sprite = e.sprite;

            slot[i].transform.GetChild(child2).GetComponentInChildren<Text>().text = e.name;

            slot[i].transform.GetChild(child3).GetComponentInChildren<Text>().text = myFunction2(e);
        }
    }
}