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
    }

    public void Generate3Character()
    {
        Characters chara1 = NewCharacter();

        characterList.Add(chara1);

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
                    case HeroClass.Assassin:
                        h.sprite = Skin[HeroClass.Assassin.ToString()];
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
            if (chara is Enemy e) //h ou Heroes h = chara as Heroes;
            {
                Debug.Log(e.enemyClass);

                //h.sprite = charaSprite[0];

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

                image.sprite = e.sprite;

                text.text = e.name;

                statsText.text = GetDisplayStatsFromChara(e);

            }
        }
    }

    public Characters NewCharacter()
    {
        Characters chara = null;

        int chooseHeroOrEnemy = Random.Range(1, 3);

        if (chooseHeroOrEnemy == 1)
        {
            HeroClass heroClass = ChooseHeroClass();

            chara = new Heroes(heroClass, MakeAName(heroClass), Util.Instance.SetRandomStats(1, 99, 9),
            Random.Range(0, 1000)/*Armor*/, Random.Range(10, 1000)/*Mana*/, Random.Range(1, 100)/*Level*/);
        }
        else if (chooseHeroOrEnemy == 2)
        {
            EnemyClass enemyClass = ChooseEnemyClass();

            chara = new Enemy(enemyClass, MakeAName(enemyClass), Util.Instance.SetRandomStats(1, 99, 9),
            Random.Range(0, 1000)/*Armor*/, Random.Range(10, 1000)/*Mana*/, Random.Range(1, 100)/*Level*/);
        }

        return chara;
    }
    public EnemyClass ChooseEnemyClass()
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
    }

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
