using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExoProjetGénérateur.Data;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject itemStats;
    public GameObject item;
    public GameObject character;

    [SerializeField]
    private EquipmentGenerator equipmentGenerator;
    [SerializeField]
    private CharacterGenerator characterGenerator;

    public void CreateItem(Equipments equipments)
    {
        GameObject i = Instantiate(item) as GameObject;
        i.transform.SetParent(this.transform);

        i.transform.GetChild(0).GetComponentInChildren<Image>().sprite = equipments.sprite;
        i.transform.GetChild(1).GetComponentInChildren<Text>().text = equipments.name;

        i.transform.GetComponent<ItemSlot>().statsString = equipmentGenerator.GetDisplayStatsFromEquip(equipments);
        i.transform.GetComponent<ItemSlot>().statsStringName = equipments.name;
    }

    public void CreateCharacter(Characters characters)
    {
        GameObject c = Instantiate(character) as GameObject;
        c.transform.SetParent(this.transform);

        c.transform.GetChild(0).GetComponentInChildren<Image>().sprite = characters.sprite;
        c.transform.GetChild(1).GetComponentInChildren<Text>().text = characters.name;

        c.transform.GetComponent<CharacterSlot>().statsString = characterGenerator.GetDisplayStatsFromChara(characters);
        c.transform.GetComponent<CharacterSlot>().statsStringName = characters.name;

    }
}
