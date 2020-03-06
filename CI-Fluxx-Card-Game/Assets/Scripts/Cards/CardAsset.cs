using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardTypes
{
    action,
    creeper,
    goal,
    keeper,
    rule
}

[CreateAssetMenu(fileName = "New Card Asset", menuName = "Card Asset")]
public class CardAsset : ScriptableObject
{
    [Header("Card Asset Information")] public new string name;
    [TextArea(2, 3)] public string description;
    public CardTypes type;
    public Sprite icon;
    public Sprite avatar;

    [Header("Goal Information")] public string[] keepers;
}