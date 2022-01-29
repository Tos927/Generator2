using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExoProjetGénérateur.Data;

public class CharacterGenerator : MonoBehaviour
{
    public Image image;

    public Text text;
    public Text statsText;

    public List<Characters> characterList = new List<Characters>();

    public List<Sprite> charaSprite = new List<Sprite>();

    public Dictionary<string, Sprite> Skin = new Dictionary<string, Sprite>();

    void Start()
    {
        foreach (var sprite in charaSprite)
        {
            Skin.Add(sprite.name, sprite);
        }

        Characters char1 = new Heroes(HeroClass.Paladin, "Uther The Great Paladin", Util.Instance.SetRandomStats(1, 99),
            Random.Range(0,1000)/*Armor*/, Random.Range(0, 1000)/*Mana*/, Random.Range(0, 100)/*Level*/);

        characterList.Add(char1);

        foreach (var chara in characterList)
        {
            if (chara is Heroes h) //h ou Heroes h = chara as Heroes;
            {
                Debug.Log(h.characterClass);

                //h.sprite = charaSprite[0];

                switch (h.characterClass)
                {
                    case HeroClass.Paladin:
                        h.sprite = Skin[HeroClass.Paladin.ToString()];
                        break;
                    case HeroClass.Thief:
                        h.sprite = Skin[HeroClass.Thief.ToString()];
                        break;
                    case HeroClass.Archer:
                        h.sprite = Skin[HeroClass.Archer.ToString()];
                        break;
                    default:
                        break;
                }

                image.sprite = h.sprite;

                text.text = h.name;

                statsText.text = GetDisplayStatsFromChara(h);

            }
        }
    }

    public void Generate3Character()
    {
        for (int i = 0; i < 3; i++)
        {

        }
    }

    public string GetDisplayStatsFromChara(Heroes h)
    {
        string stats =

            "Level : " + h.level + "\n" +
            "HP : " + h.life + "\n" +
            "Mana : " + h.mana + "\n" +
            "Stamina : " + h.stamina + "\n" + "\n" +

            "Vitality : " + h.stats.vitality + "\n" +
            "Memory : " + h.stats.memory + "\n" +
            "Stamina : " + h.stats.stamina + "\n" +
            "Strength : " + h.stats.strength + "\n" +
            "Dexterity : " + h.stats.dexterity + "\n" +
            "Agility : " + h.stats.agility + "\n" +
            "Intellect : " + h.stats.intellect + "\n" +
            "Faith : " + h.stats.faith + "\n" +
            "Luck : " + h.stats.luck + "\n";

        return stats;
    }

    

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
