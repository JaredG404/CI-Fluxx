using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICards : MonoBehaviour
{
    public enum CardType
    {
        KEEPER,
        GOALS,
        RULE
    }
    public Image image_cards;
    public GameObject gob_FrontCard;
    public CardType type;
    public string Name;
    public string keepersNeededforGoal1;
    public string keepersNeededforGoal2; 
    public bool isThisCardYours = false;
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
        else if(string.Compare(str, "goal") == 0)
        {
            type = CardType.GOALS;
        }
        else
        {
            type = CardType.RULE;
        }
        KeepersForTheGoal();
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
    public bool isRule()
    {
        if(type == CardType.RULE)
        {
            return true;
        }else{
            return false;
        }
    }
    public void KeepersForTheGoal()
    {
        if(isGoal())
        {
            if(string.Compare(Name, "goal-The Duo") == 0)
            {
                keepersNeededforGoal1 = "keeper-AJ Bieszczad";
                keepersNeededforGoal2 = "keeper-Anna";
            }
        }
    }
    public string getName()
    {
        return Name;
    }

    public bool CheckIfThisCardIsYours()
    {
        return isThisCardYours;
    }
    public void SetIsThisCardYours(bool x)
    {
        isThisCardYours = x;
    }
}
