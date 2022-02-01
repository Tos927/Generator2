using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExoProjetGénérateur.Data;
using System.Reflection;

public class EquipmentGenerator : GeneratorManager
{
    private Range equipmentRange;
    private EquipementType equipementType;

    public List<Equipments> equipmentsList = new List<Equipments>();

    //Put a space after the adjective
    private List<string> equipmentAdj = new List<string>(){ "Holy ", "Titanic ", "Marvelous ", "Forcefull ", "Mythril ", 
        "Obsidian ", "Diamond ", "Demonic ", "God's ", "Hercules's ", "Lucifer's " };

    private int damageBlock; //en pourcentage

    protected override void Start()
    {
        base.Start();
    }

    public int howManyGenerationGetSet
    {
        get { return howManyGeneration; }
        set { howManyGeneration = value; }
    }

    public void GenerateEquipment()
    {

        int[] choice = new int[howManyGeneration];

        for (int i = 0; i < howManyGeneration; i++)
        {
            //to allow the 0 to exist as an index
            //bc we check if different than the value in choice[i] 
            choice[i] = -1;

            //index
            int randomChoice = Random.Range(0, 6);

            // Choose a number from the Random.Range above and if already
            // choosed during the loop changes it until a new number appears
            choice[i] = Util.Instance.NewNumber(choice, i, randomChoice, 0, 6);

            Equipments newEquip = NewEquipement(choice[i]);

            equipmentsList.Add(newEquip);

            if (newEquip is Offensive o)
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

                Util.Instance.DisplayTheGeneration<Equipments>(slot, i, 2, 3, 4, newEquip, null, newEquip.GetDisplayStatsFromEquip);
            }
            else if (newEquip is Defensive d)
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

                Util.Instance.DisplayTheGeneration<Equipments>(slot, i, 2, 3, 4, newEquip, null, newEquip.GetDisplayStatsFromEquip);
            }

            inventory.CreateItem(newEquip);
        }
    }

    public Equipments NewEquipement(int equipChoice)
    {
        Equipments equip = null;

        int rdmEquipmentAdj = Random.Range(0, equipmentAdj.Count);
        int levelNeaded = Random.Range(1, 100);

        if (equipChoice < 3)
        {
            int rdmRange = Random.Range(0, 3);
            switch (rdmRange)
            {
                case 0:
                    equipmentRange = Range.Short;
                    break;
                case 1:
                    equipmentRange = Range.Medium;
                    break;
                case 2:
                    equipmentRange = Range.Long;
                    break;
                default:
                    break;
            }
        }

        switch (equipChoice)
        {
            case 0:
                equipementType = EquipementType.Sword;
                damageBlock = Random.Range(10, 70);
                break;
            case 1:
                equipementType = EquipementType.Bow;
                damageBlock = Random.Range(1, 20);
                break;
            case 2:
                equipementType = EquipementType.MagicStaff;
                damageBlock = Random.Range(1, 30);
                break;
            case 3:
                equipementType = EquipementType.Shield;
                damageBlock = Random.Range(30, 100);
                break;
            case 4:
                equipementType = EquipementType.Armor;
                damageBlock = Random.Range(5, 30);
                break;
            case 5:
                equipementType = EquipementType.Claymore;
                damageBlock = 0;
                break;
            default:
                break;
        }

        if (equipChoice < 3)
        {
            equip = new Offensive(equipmentAdj[rdmEquipmentAdj] + equipementType.ToString(), Util.Instance.SetRandomStats(1, 10, 3), 
                damageBlock, levelNeaded, equipementType, /*AttackPoint*/levelNeaded * 10, /*CriticalChance*/Random.Range(100, 600),
                /*CriticalDamage*/Random.Range(100, 600), equipmentRange);
        }
        else if (equipChoice >= 3)
        {
            equip = new Defensive(equipmentAdj[rdmEquipmentAdj] + equipementType.ToString(), Util.Instance.SetRandomStats(1, 10, 3),
                    damageBlock, levelNeaded, equipementType, /*MagicalArmor*/Random.Range(100, 600),
                    /*PhysicalArmor*/ Random.Range(100, 600));
        }

        return equip;
    }

    public string GetDisplayStatsFromEquip (Equipments e)
    {
        string stats =

            "Level Required : " + e.levelRequiered + "\n" +
            "Damage Blocked : " + e.damageBlock + " %\n\n";

        if (e is Offensive o)
        {
            stats += 
                "Attack Point : " + o.attackPoint + "\n" +
                "Criticale Damage : " + o.criticalDamage + "\n" +
                "Criticale Chance : " + o.criticalChance + "\n\n";
        }
        else if (e is Defensive d)
        {
            stats +=
                "Physical Armor : " + d.physicalArmor + "\n" +
                "Magical Armor : " + d.magicalArmor + "\n\n";
        }

        foreach (var field in typeof(Stats).GetFields(BindingFlags.Instance |
                                                 BindingFlags.NonPublic |
                                                 BindingFlags.Public))
        {
            object t = field.GetValue(e.stats);
            switch (t)
            {
                case 0:
                    break;
                default:
                    stats +=
                        field.Name + " : " + t + "\n";
                    break;
            }
        }

        return stats;
    }
}
