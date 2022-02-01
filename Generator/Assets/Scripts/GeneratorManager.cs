using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeneratorManager : MonoBehaviour
{
    public Inventory inventory;

    public int howManyGeneration = 3;

    [SerializeField]
    protected GameObject[] slot = new GameObject[3];

    [SerializeField]
    protected List<Sprite> sprite = new List<Sprite>();

    public Dictionary<string, Sprite> Skin = new Dictionary<string, Sprite>();

    protected virtual void Start()
    {
        foreach (var sprite in sprite)
        {
            Skin.Add(sprite.name, sprite);
        }
    }
}
