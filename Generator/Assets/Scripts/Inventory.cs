using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExoProjetGénérateur.Data;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject itemStats;
    public GameObject item;

    [SerializeField]
    private EquipmentGenerator equipmentGenerator;

    public void CreateItem(Equipments equipments)
    {
        GameObject a = Instantiate(item) as GameObject;
        a.transform.SetParent(this.transform);

        a.transform.GetChild(0).GetComponentInChildren<Image>().sprite = equipments.sprite;
        a.transform.GetChild(1).GetComponentInChildren<Text>().text = equipments.name;

        a.transform.GetComponent<ItemSlot>().statsString = equipmentGenerator.GetDisplayStatsFromEquip(equipments);
    }
}
