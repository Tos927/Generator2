using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExoProjetGénérateur.Data;
using System.Reflection;

public class EquipmentGenerator : MonoBehaviour
{
    private Range equipmentRange;
    private EquipementType equipementType;

    public Image image;
    public Text statsText;
    public Text nameText;
    public Image image1;
    public Text statsText1;
    public Text nameText1;
    public Image image2;
    public Text statsText2;
    public Text nameText2;

    public List<Equipments> equipmentsList = new List<Equipments>();

    public List<Sprite> equipmentSprite = new List<Sprite>();

    private List<string> equipmentAdj = new List<string>(){ "Holy", "Titanic", "Marvelous", "Forcefull", "Mythril", 
        "Obsidian", "Diamond", "Demonic", "God's", "Hercules's", "Lucifer's" };

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
            int rdmEquipmentAdj = Random.Range(0, 11);
            int levelNeaded = Random.Range(1, 100);
            int attackPoint = levelNeaded * 10;

            if (rdmEquipmentType < 3)
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

            switch (rdmEquipmentType)
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

            if (rdmEquipmentType == 0 || rdmEquipmentType == 1 || rdmEquipmentType == 2 )
            {
                Equipments newEquipment = new Offensive(equipmentAdj[rdmEquipmentAdj], Util.Instance.SetRandomStats(1, 10, 3), damageBlock, levelNeaded,
                    equipementType, attackPoint, /*CriticalChance*/Random.Range(100, 600), /*CriticalDamage*/Random.Range(100, 600), equipmentRange);
                equipmentsList.Add(newEquipment);
            }
            else if (rdmEquipmentType == 3 || rdmEquipmentType == 4 || rdmEquipmentType == 5)
            {
                Equipments newEquipment = new Defensive(equipmentAdj[rdmEquipmentAdj], Util.Instance.SetRandomStats(1, 10, 3),
                    damageBlock, levelNeaded, equipementType, /*Magicalarmor*/Random.Range(100, 600),/*Physicalarmor*/ Random.Range(100, 600));
                equipmentsList.Add(newEquipment);
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
            image.sprite = equipments.sprite;
            nameText.text = equipments.name + " " + equipementType.ToString();
            statsText.text = GetDisplayStatsFromEquip(equipments);
        }
    }
    public string GetDisplayStatsFromEquip (Equipments e)
    {
        string stats =

            "Level Required : " + e.levelRequiered + "\n" +
            "Damage Blocked : " + e.damageBlock + "\n\n";

        

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
