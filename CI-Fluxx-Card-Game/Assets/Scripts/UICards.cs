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
        int index = Name.IndexOf("-");
        string str = Name.Substring(0, index);
        Debug.Log(str);
        if(string.Compare(str, "keeper") == 0)
        {
            type = CardType.KEEPER;
        }
        else
        {
            type = CardType.GOALS;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool isGoal()
    {
        if(type == CardType.GOALS)
        {
            return true;
        }else{
            return false;
        }
    }
    public bool isKeeper()
    {
        if(type == CardType.KEEPER)
        {
            return true;
        }else{
            return false;
        }
    }
}
