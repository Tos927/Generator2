using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExoProjetGénérateur.Data;

public class Test : MonoBehaviour
{
    public Range rangeTest;
    public EquipementType typeTestOf;
    public EquipementType typeTestDef;

    public List<Equipments> equipmentsList = new List<Equipments>();

    public List<Sprite> equipmentSprite = new List<Sprite>();

    public Dictionary<string, Sprite> Skin = new Dictionary<string, Sprite>();

    //public int attackPointGet { get; }

    private void Start()
    {
        foreach (var sprite in equipmentSprite)
        {
            Skin.Add(sprite.name, sprite);
        }
    }

    public void GenerateEquipment()
    {
        for (int i = 0; i < 3; i++)
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

            int rdmEquipmentTypeOf = Random.Range(0, 3);

            switch (rdmEquipmentTypeOf)
            {
                case 0:
                    typeTestOf = EquipementType.Sword;
                    break;
                case 1:
                    typeTestOf = EquipementType.Bow;
                    break;
                case 2:
                    typeTestOf = EquipementType.MagicStaff;
                    break;
                default:
                    break;
            }


            int rdmEquipmentTypeDef = Random.Range(3, 6);

            switch (rdmEquipmentTypeDef)
            {
                case 3:
                    typeTestDef = EquipementType.Shield;
                    break;
                case 4:
                    typeTestDef = EquipementType.Armor;
                    break;
                case 5:
                    typeTestDef = EquipementType.Claymore;
                    break;
                default:
                    break;
            }
            int rdmOfDef = Random.Range(0, 2);



            switch (rdmOfDef)  
            {
                case 0:
                    Equipments testOf = new Offensive("Jérôme", new Stats(1, 1, 1, 1, 1, 1, 1, 1, 1), 1, 1, typeTestOf, 1, 1, 1, rangeTest);
                    equipmentsList.Add(testOf);
                    break;
                case 1:
                    Equipments testDef = new Defensive("Franck'O", new Stats(1, 1, 1, 1, 1, 1, 1, 1, 1), 1, 1, typeTestDef, 1, 1);
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
