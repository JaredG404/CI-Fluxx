using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardManager : MonoBehaviour
{
    public CardAsset cardAsset;
    public CardManager previewManager; // Need more info
    public new Text name;
    public Text description;
    public Text verticalName;
    public Text type;
    public Image accent;
    public Image avatar;
    public Image icon;

    void Awake()
    {
        if (null != cardAsset)
            ReadCardAsset();
    }

    // Video 12 has function for glowing card border while draggin
    
    public void ReadCardAsset()
    {
        name.text = cardAsset.name;
        description.text = cardAsset.description;
        verticalName.text = cardAsset.name;
        avatar.sprite = cardAsset.avatar;
        icon.sprite = cardAsset.icon;
        
        switch (cardAsset.type)
        {
            case CardTypes.action:
                accent.color = Color.blue;
                type.text = "ACTION";
                break;
            case CardTypes.creeper:
                accent.color = Color.black;
                type.text = "CREEPER";
                break;
            case CardTypes.goal:
                accent.color = Color.magenta;
                type.text = "GOAL";
                break;
            case CardTypes.keeper:
                accent.color = Color.green;
                type.text = "KEEPER";
                break;
            case CardTypes.rule:
                accent.color = Color.yellow;
                type.text = "RULE";
                break;
            default:
                Debug.Log("Invalid Card Type: CardEditor.cs");  
                break;
        }

        if (null != previewManager)
        {
            previewManager.cardAsset = cardAsset;
            previewManager.ReadCardAsset();
        }
    }
}
