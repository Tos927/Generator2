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

                slot[i].transform.GetChild(1).GetComponentInChildren<Image>().sprite = h.sprite;

                slot[i].transform.GetChild(3).GetComponentInChildren<Text>().text = h.name;

                slot[i].transform.GetChild(4).GetComponentInChildren<Text>().text = GetDisplayStatsFromChara(h);

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

                slot[i].transform.GetChild(1).GetComponentInChildren<Image>().sprite = e.sprite;

                slot[i].transform.GetChild(3).GetComponentInChildren<Text>().text = e.name;

                slot[i].transform.GetChild(4).GetComponentInChildren<Text>().text = GetDisplayStatsFromChara(e);

            }
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

    public Characters NewCharacter(int charaChoice)
    {
        Characters chara = null;

        //int chooseHeroOrEnemy = Random.Range(1, 3);

        Debug.Log("NewCharacter");
        Debug.Log(charaChoice);

        if (charaChoice < 3)
        {
            HeroClass heroClass = (HeroClass)charaChoice;

            chara = new Heroes(heroClass, MakeAName(heroClass), Util.Instance.SetRandomStats(1, 99, 9),
            Random.Range(0, 1000)/*Armor*/, Random.Range(10, 1000)/*Mana*/, Random.Range(1, 100)/*Level*/);
        }
        else if (charaChoice >= 3)
        {
            EnemyClass enemyClass = (EnemyClass)charaChoice;

            chara = new Enemy(enemyClass, MakeAName(enemyClass), Util.Instance.SetRandomStats(1, 99, 9),
            Random.Range(0, 1000)/*Armor*/, Random.Range(10, 1000)/*Mana*/, Random.Range(1, 100)/*Level*/);
        }

        return chara;
    }
    /*public EnemyClass ChooseEnemyClass()
    {
        EnemyClass e;

        int randomEnemyClass = Random.Range(0, 3);

        e = (EnemyClass)randomEnemyClass;

        return e;
    }
    public HeroClass ChooseHeroClass()
    {
        HeroClass h;

        int randomHeroClass = Random.Range(0, 3);

        h = (HeroClass)randomHeroClass;

        return h;
    }*/

    /*public string MakeAName(Characters classChara)
    {
        //Heroes h = heroclass as Heroes;

        if(classChara is Heroes h)
        {
            switch (HeroClass)
            {
                case HeroClass.Paladin:
                    name = "Uther the " + HeroClass.Paladin.ToString();
                    break;
                case HeroClass.Thief:
                    name = "Rogue the " + HeroClass.Thief.ToString();
                    break;
                case HeroClass.Archer:
                    name = "Legolas the " + HeroClass.Archer.ToString();
                    break;
                default:
                    break;
            }
        }
        else if(classChara is Enemy e)
        {

        }

        string name = "";

        


        return name;
    }*/
    public string MakeAName(HeroClass heroclass)
    {
        string name = "";

        switch (heroclass)
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
        
        return name;
    }

    public string MakeAName(EnemyClass enemyclass)
    {
        string name = "";

        switch (enemyclass)
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

        return name;
    }

    public string GetDisplayStatsFromChara(Characters h)
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


    // Update is called once per frame
    void Update()
    {
        
    }
}
