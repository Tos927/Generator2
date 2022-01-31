using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExoProjetGénérateur.Data;
using UnityEngine.UI;

public class CharacterSlot : MonoBehaviour
{
    public GameObject characterSlot;
    public GameObject itemStats;

    public string statsStringName;
    public string statsString;

    [SerializeField]
    private Inventory inventory;

    private void Awake()
    {
        characterSlot = this.gameObject;
    }

    public void OpenStats()
    {
        itemStats = GameObject.FindGameObjectWithTag("ItemStats");
        itemStats.transform.GetChild(0).gameObject.SetActive(true);
        itemStats.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void SetStats()
    {
        itemStats.transform.GetChild(1).GetChild(0).GetComponentInChildren<Text>().text = statsStringName + "\n\n" + statsString;
    }
}
