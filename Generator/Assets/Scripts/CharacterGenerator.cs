using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExoProjetGénérateur.Data;

public class CharacterGenerator : MonoBehaviour
{
    public GameObject[] slot = new GameObject[3];

    public List<Characters> characterList = new List<Characters>();

    public List<Sprite> charaSprite = new List<Sprite>();

    public Dictionary<string, Sprite> Skin = new Dictionary<string, Sprite>();

    void Start()
    {
        foreach (var sprite in charaSprite)
        {
            Skin.Add(sprite.name, sprite);
        }

        /*
        foreach (var chara in characterList)
        {
            if (chara is Heroes h) //h ou Heroes h = chara as Heroes;
            {
                switch (h.characterClass)
                {
                    case HeroClass.Paladin:
                        h.sprite = Skin[HeroClass.Paladin.ToString()];
                        break;
                    case HeroClass.Assassin:
                        h.sprite = Skin[HeroClass.Assassin.ToString()];
                        break;
                    case HeroClass.Archer:
                        h.sprite = Skin[HeroClass.Archer.ToString()];
                        break;
                    default:
                        break;
                }

                slot[0].transform.GetChild(1).GetComponentInChildren<Image>().sprite = h.sprite;

                slot[0].transform.GetChild(3).GetComponentInChildren<Text>().text = h.name;

                slot[0].transform.GetChild(4).GetComponentInChildren<Text>().text = GetDisplayStatsFromChara(h);

            }
        }*/
    }

    public void GenerateCharacters()
    {
        int howManyCharacters = 3;

        int[] choice = new int[howManyCharacters];

        for (int i = 0; i < howManyCharacters; i++)
        {
            //to allow the 0 to exist as an index
            //bc we check if different than the value in choice[i] 
            choice[i] = -1;

            //index
            int randomChoice = Random.Range(0, 6);

            // Choose a number from the Random.Range above and if already
            // choosed during the loop changes it until a new number appears
            choice[i] = Util.Instance.NewNumber(choice, i, randomChoice, 0, 6);

            Characters newChara = NewCharacter(choice[i]);

            characterList.Add(newChara);

            if (newChara is Heroes h) //h ou Heroes h = chara as Heroes;
            {
                switch (h.characterClass)
                {
                    case HeroClass.Paladin:
                        h.sprite = Skin[HeroClass.Paladin.ToString()];
                        break;
                    case HeroClass.Assassin:
                        h.sprite = Skin[HeroClass.Assassin.ToString()];
                        break;
                    case HeroClass.Archer:
                        h.sprite = Skin[HeroClass.Archer.ToString()];
                        break;
                    default:
                        break;
                }

                Util.Instance.DisplayTheGeneration<Characters>(slot, i, 1, 3, 4, newChara, GetDisplayStatsFromChara);

                //I keep that in case the function above doesn't work anymore or bug
                /*slot[i].transform.GetChild(1).GetComponentInChildren<Image>().sprite = h.sprite;

                slot[i].transform.GetChild(3).GetComponentInChildren<Text>().text = h.name;

                slot[i].transform.GetChild(4).GetComponentInChildren<Text>().text = GetDisplayStatsFromChara(h);*/

            }
            if (newChara is Enemy e) //e ou Enemy e = chara as Enemy;
            {
                switch (e.enemyClass)
                {
                    case EnemyClass.Troll:
                        e.sprite = Skin[EnemyClass.Troll.ToString()];
                        break;
                    case EnemyClass.Goblin:
                        e.sprite = Skin[EnemyClass.Goblin.ToString()];
                        break;
                    case EnemyClass.Lich:
                        e.sprite = Skin[EnemyClass.Lich.ToString()];
                        break;
                    default:
                        break;
                }

                Util.Instance.DisplayTheGeneration<Characters>(slot, i, 1, 3, 4, newChara, GetDisplayStatsFromChara);
            }
        }
    }

    

    public Characters NewCharacter(int charaChoice)
    {
        Characters chara = null;

        if (charaChoice < 3)
        {
            HeroClass heroClass = (HeroClass)charaChoice;

            chara = new Heroes(heroClass, Util.Instance.SetRandomStats(1, 99, 9),
            Random.Range(0, 1000)/*Armor*/, Random.Range(10, 1000)/*Mana*/, Random.Range(1, 100)/*Level*/);

            //Override the default name
            chara.name = MakeANameForChara(chara);
        }
        else if (charaChoice >= 3)
        {
            EnemyClass enemyClass = (EnemyClass)charaChoice;

            chara = new Enemy(enemyClass, Util.Instance.SetRandomStats(1, 99, 9),
            Random.Range(0, 1000)/*Armor*/, Random.Range(10, 1000)/*Mana*/, Random.Range(1, 100)/*Level*/);

            //Override the default name
            chara.name = MakeANameForChara(chara);
        }

        return chara;
    }

    private string MakeANameForChara(Characters classChara)
    {
        string name = "";

        if (classChara is Heroes h)
        {
            switch (h.characterClass)
            {
                case HeroClass.Paladin:
                    name = "Uther the Holy " + HeroClass.Paladin.ToString();
                    break;
                case HeroClass.Assassin:
                    name = "Valeera The Master " + HeroClass.Assassin.ToString();
                    break;
                case HeroClass.Archer:
                    name = "Sylvanas Coursevent the " + HeroClass.Archer.ToString();
                    break;
                default:
                    break;
            }
        }
        else if (classChara is Enemy e)
        {
            switch (e.enemyClass)
            {
                case EnemyClass.Troll:
                    name = EnemyClass.Troll.ToString() + " Warlord Zul'Jin";
                    break;
                case EnemyClass.Goblin:
                    name = "Jastor Gallywix Prince " + EnemyClass.Goblin.ToString();
                    break;
                case EnemyClass.Lich:
                    name = "The " + EnemyClass.Lich.ToString() + " King";
                    break;
                default:
                    break;
            }
        }

        return name;
    }

    private string GetDisplayStatsFromChara(Characters h)
    {
        string stats =

            "Level : " + h.level + "\n" +
            "HP : " + h.life + "\n" +
            "Mana : " + h.mana + "\n" +
            "Stamina : " + h.stamina + "\n\n" +

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
}
