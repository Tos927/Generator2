using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExoProjetGénérateur.Data;

public class Test : MonoBehaviour
{
    private Range rangeTest;
    private EquipementType typeTestOf;
    private EquipementType typeTestDef;
    private EquipmentName equipmentName;

    public List<Equipments> equipmentsList = new List<Equipments>();

    public List<Sprite> equipmentSprite = new List<Sprite>();

    public Dictionary<string, Sprite> Skin = new Dictionary<string, Sprite>();


    private int damageBlock; //en pourcentage

    private void Start()
    {
        foreach (var sprite in equipmentSprite)
        {
            Skin.Add(sprite.name, sprite);
        }
    }

    public void GenerateEquipment()
    {
        for (int i = 0; i < 1; i++)
        {
            int rdmEquipmentType = Random.Range(0, 6);
            int rdmEquipmentName = Random.Range(0, 11);
            int levelRequiered = Random.Range(1, 100);
            int attackPoint = levelRequiered * 10;

            if (rdmEquipmentType < 3)
            {
                int rdmRange = Random.Range(0, 3);
                switch (rdmRange)
                {
                    case 0:
                        rangeTest = Range.Short;
                        break;
                    case 1:
                        rangeTest = Range.Medium;
                        break;
                    case 2:
                        rangeTest = Range.Long;
                        break;
                    default:
                        break;
                }
            }

            switch (rdmEquipmentType)
            {
                case 0:
                    typeTestOf = EquipementType.Sword;
                    damageBlock = Random.Range(10, 70);
                    break;
                case 1:
                    typeTestOf = EquipementType.Bow;
                    damageBlock = Random.Range(1, 20);
                    break;
                case 2:
                    typeTestOf = EquipementType.MagicStaff;
                    damageBlock = Random.Range(1, 30);
                    break;
                case 3:
                    typeTestDef = EquipementType.Shield;
                    damageBlock = Random.Range(30, 100);
                    break;
                case 4:
                    typeTestDef = EquipementType.Armor;
                    damageBlock = Random.Range(5, 30);
                    break;
                case 5:
                    typeTestDef = EquipementType.Claymore;
                    damageBlock = 0;
                    break;
                default:
                    break;
            }

            switch (rdmEquipmentName)
            {
                case 0:
                    equipmentName = EquipmentName.Holy;
                    break;
                case 1:
                    equipmentName = EquipmentName.Titanic;
                    break;
                case 2:
                    equipmentName = EquipmentName.Marvelous;
                    break;
                case 3:
                    equipmentName = EquipmentName.Forcefull;
                    break;
                case 4:
                    equipmentName = EquipmentName.Mythril;
                    break;
                case 5:
                    equipmentName = EquipmentName.Obsidian;
                    break;
                case 6:
                    equipmentName = EquipmentName.Diamond;
                    break;
                case 7:
                    equipmentName = EquipmentName.Demonic;
                    break;
                case 8:
                    equipmentName = EquipmentName.God_s;
                    break;
                case 9:
                    equipmentName = EquipmentName.Hercules_s;
                    break;
                case 10:
                    equipmentName = EquipmentName.Lucifer_s;
                    break;
                default:
                    break;
            }
            int rdmOfDef = Random.Range(0, 2);
            

            switch (rdmOfDef)
            {
                case 0:
                    Equipments testOf = new Offensive(equipmentName.ToString(), Util.Instance.SetRandomStats(0, 10), damageBlock, levelRequiered, typeTestOf, attackPoint, /*CriticalChance*/Random.Range(100, 600), /*CriticalDamage*/Random.Range(100, 600), rangeTest);
                    equipmentsList.Add(testOf);
                    break;
                case 1:
                    Equipments testDef = new Defensive(equipmentName.ToString(), Util.Instance.SetRandomStats(0, 10), damageBlock, levelRequiered, typeTestDef, /*Magicalarmor*/Random.Range(100, 600),/*Physicalarmor*/ Random.Range(100, 600));
                    equipmentsList.Add(testDef);
                    break;
                default:
                    break;
            }

        }

        foreach (var equipments in equipmentsList)
        {
            if (equipments is Offensive o)
            {
                switch (o.equipementType)
                {
                    case EquipementType.Sword:
                        o.sprite = Skin[EquipementType.Sword.ToString()];
                        break;
                    case EquipementType.Bow:
                        o.sprite = Skin[EquipementType.Bow.ToString()];
                        break;
                    case EquipementType.MagicStaff:
                        o.sprite = Skin[EquipementType.MagicStaff.ToString()];
                        break;
                    default:
                        break;
                }
            }
            else if (equipments is Defensive d)
            {
                switch (d.equipementType)
                {
                    case EquipementType.Shield:
                        d.sprite = Skin[EquipementType.Shield.ToString()];
                        break;
                    case EquipementType.Armor:
                        d.sprite = Skin[EquipementType.Armor.ToString()];
                        break;
                    case EquipementType.Claymore:
                        d.sprite = Skin[EquipementType.Claymore.ToString()];
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
