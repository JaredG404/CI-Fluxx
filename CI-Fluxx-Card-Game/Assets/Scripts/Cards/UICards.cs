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
    public string keepersNeededforGoal3;
    public string keepersNeededforGoal4;
    public string keepersNeededforGoal5;
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
            if(string.Compare(Name, "The Duo") == 0)
            {
                keepersNeededforGoal1 = "AJBieszczad";
                keepersNeededforGoal2 = "AnnaBieszczad";
            }
            if(string.Compare(Name, "AnotherDayOnTheJob") == 0)
            {
                keepersNeededforGoal1 = "Marker";
                keepersNeededforGoal2 = "Nick";
            }
            if(string.Compare(Name, "BoredProblems") == 0)
            {
                keepersNeededforGoal1 = "Marker";
                keepersNeededforGoal2 = "AJ";
            }
            if(string.Compare(Name, "DinnerTime") == 0)
            {
                keepersNeededforGoal1 = "Pizza";
                keepersNeededforGoal2 = "Radish";
            }
            if(string.Compare(Name, "Graduation") == 0)
            {
                // problems adding multiple teachers for goal
                // Right now only accepts diploma and AJ
                keepersNeededforGoal1 = "Diploma";
                keepersNeededforGoal2 = "AJBieszczad";
                keepersNeededforGoal3 = "AnnaBieszczad";
                keepersNeededforGoal4 = "Nick";
                keepersNeededforGoal5 = "Ryan";
            }
            if(string.Compare(Name, "GraduationParty") == 0)
            {
                keepersNeededforGoal1 = "Diploma";
                keepersNeededforGoal2 = "Pizza";
            }
            if(string.Compare(Name, "LunchBreak") == 0)
            {
                // problems adding multiple teachers for goal
                // Right now only accepts pizza and Ryan 
                keepersNeededforGoal1 = "Pizza";
                keepersNeededforGoal2 = "Ryan";
                keepersNeededforGoal3 = "Nick";
            }
            if(string.Compare(Name, "StructuredLearning") == 0)
            {
                keepersNeededforGoal1 = "Marker";
                keepersNeededforGoal2 = "AnnaBieszczad";
            }
            if(string.Compare(Name, "Vandalism") == 0)
            {
                keepersNeededforGoal1 = "Radish";
                keepersNeededforGoal2 = "Nick";
            }
            if(string.Compare(Name, "WaitHowOldAreYou") == 0)
            {
                keepersNeededforGoal1 = "Ryan";
                keepersNeededforGoal2 = "Nick";
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
