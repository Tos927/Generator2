using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExoProjetGénérateur.Data;

public class CharacterInventory : MonoBehaviour
{
    public List<Characters> charactersCreated = new List<Characters>();

    public CharacterGenerator characterGenerator;

    public GameObject leftArrow;
    public GameObject rightArrow;

    public int index = 0;

    private static CharacterInventory _instance = null;
    public static CharacterInventory Instance
    {
        get => _instance;
    }
    private void Awake()
    {
        _instance = this;

        index = 0;
    }

    public void Update()
    {
        Debug.Log(characterGenerator.characterList.Count);

        if (!characterGenerator.listCharaIsEmpty)
        {
            if (this.transform.GetChild(1).GetComponentInChildren<Image>().sprite != characterGenerator.characterList[index].sprite
            && this.transform.GetChild(3).GetComponentInChildren<Text>().text != characterGenerator.characterList[index].name
            && this.transform.GetChild(4).GetComponentInChildren<Text>().text != characterGenerator.GetDisplayStatsFromChara(characterGenerator.characterList[index]))
            {
                if (index == 0)
                {
                    leftArrow.SetActive(false);
                }
                else
                {
                    leftArrow.SetActive(true);
                }

                this.transform.GetChild(1).GetComponentInChildren<Image>().sprite = characterGenerator.characterList[index].sprite;

                this.transform.GetChild(3).GetComponentInChildren<Text>().text = characterGenerator.characterList[index].name;

                this.transform.GetChild(4).GetComponentInChildren<Text>().text = characterGenerator.GetDisplayStatsFromChara(characterGenerator.characterList[index]);
            }
        }
        if (index == (characterGenerator.characterList.Count - 1))
        {
            rightArrow.SetActive(false);
        }
        else
        {
            rightArrow.SetActive(true);
        }
    }

    public void ChangeIndex(bool up)
    {
        if (up)
        {
            index = Mathf.Clamp(index, 0, characterGenerator.characterList.Count - 2) + 1;
        }
        else if (!up)
        {
            index = Mathf.Clamp(index, 1, characterGenerator.characterList.Count) - 1;
        }
    }
}
