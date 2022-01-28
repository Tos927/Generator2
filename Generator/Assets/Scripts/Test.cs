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

    //public int attackPointGet { get; }

    public void GenerateEquipment()
    {
        int rdmRange = Random.Range(0, 2);

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

        int rdmEquipmentTypeOf = Random.Range(0, 2);

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


        int rdmEquipmentTypeDef = Random.Range(3, 5);

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

        for (int i = 0; i < 3; i++)
        {
            Equipments testOf = new Offensive("Jérôme", new Stats(1, 1, 1, 1, 1, 1, 1, 1, 1), 1, 1, typeTestOf, 1, 1, 1, rangeTest);
            //Debug.Log(attackPointGet);
            Equipments testDef = new Defensive("Franck'O", new Stats(1, 1, 1, 1, 1, 1, 1, 1, 1), 1, 1, typeTestDef, 1, 1);
            Debug.Log(testDef);
        }
    }
}
