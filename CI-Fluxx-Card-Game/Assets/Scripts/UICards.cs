using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICards : MonoBehaviour
{
    public enum CardType
    {
        KEEPER,
        GOALS

    }
    public Image image_cards;
    public GameObject gob_FrontCard;
    public CardType type;
    public string Name;
    // Start is called before the first frame update
    void Start()
    {
        Name = image_cards.sprite.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
