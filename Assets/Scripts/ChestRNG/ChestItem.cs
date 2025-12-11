using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity
{
    Common,
    Rare,
    Legendary
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ChestItem", order = 1)]
public class ChestItem : ScriptableObject
{

    public Rarity Rarity;
    public string Name;
    public GameObject Item;
    public Sprite sprite;
    [Range(0, 100)]
    public float dropchancePrecentage;
}
