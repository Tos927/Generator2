using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExoProjetGénérateur.Data;

public class CharacterGenerator : MonoBehaviour
{
    public Image image;

    public Text text;

    public List<Characters> characterList = new List<Characters>();

    public List<Sprite> charaSprite = new List<Sprite>();

    public Dictionary<string, Sprite> Skin = new Dictionary<string, Sprite>();

    void Start()
    {
        foreach (var item in charaSprite)
        {
            Skin.Add(item.name, item);
        }

        Characters char1 = new Heroes(HeroClass.Paladin, "Uter", new Stats(1, 2, 3, 4, 5, 6, 7, 8, 9), 
            RandomInt(0,1000), RandomInt(0, 1000), RandomInt(0, 100));

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
            }
        }

        
    }

    public void Generate3Character()
    {

    }

    public int RandomInt(int min, int max)
    {
        int randomInt = Random.Range(min, max);

        return randomInt;
    }

    public Stats Salut()
    {
        Stats statsRandom = new Stats();

/*        int newStats = 0;

        for (int i = 0; i < 8; i++)
        {
            newStats = Random.Range(1, 99);

            statsRandom.vitality = newStats;
        }*/

        return statsRandom;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
