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
            if(string.Compare(Name, "goal-TheDuo") == 0)
            {
                keepersNeededforGoal1 = "keeper-AJBieszczad";
                keepersNeededforGoal2 = "keeper-AnnaBieszczad";
            }
            if(string.Compare(Name, "goal-AnotherDayOnTheJob") == 0)
            {
                keepersNeededforGoal1 = "keeper-Marker";
                keepersNeededforGoal2 = "keeper-Nick";
            }
            if(string.Compare(Name, "goal-BoredProblems") == 0)
            {
                keepersNeededforGoal1 = "keeper-Marker";
                keepersNeededforGoal2 = "keeper-AJ";
            }
            if(string.Compare(Name, "goal-DinnerTime") == 0)
            {
                keepersNeededforGoal1 = "keeper-Pizza";
                keepersNeededforGoal2 = "keeper-Radish";
            }
            if(string.Compare(Name, "goal-Graduation") == 0)
            {
                keepersNeededforGoal1 = "keeper-Diploma";
                keepersNeededforGoal2 = "keeper-AJBieszczad";
                keepersNeededforGoal3 = "keeper-AnnaBieszczad";
                keepersNeededforGoal4 = "keeper-Nick";
                keepersNeededforGoal5 = "keeper-Ryan";
            }
            if(string.Compare(Name, "goal-GraduationParty") == 0)
            {
                keepersNeededforGoal1 = "keeper-Diploma";
                keepersNeededforGoal2 = "keeper-Pizza";
            }
            if(string.Compare(Name, "goal-LunchBreak") == 0)
            {
                keepersNeededforGoal1 = "keeper-Pizza";
                keepersNeededforGoal2 = "keeper-Ryan";
                keepersNeededforGoal3 = "keeper-Nick";
            }
            if(string.Compare(Name, "goal-StructuredLearning") == 0)
            {
                keepersNeededforGoal1 = "keeper-Marker";
                keepersNeededforGoal2 = "keeper-AnnaBieszczad";
            }
            if(string.Compare(Name, "goal-Vandalism") == 0)
            {
                keepersNeededforGoal1 = "keeper-Radish";
                keepersNeededforGoal2 = "keeper-Nick";
            }
            if(string.Compare(Name, "goal-WaitHowOldAreYou") == 0)
            {
                keepersNeededforGoal1 = "keeper-Ryan";
                keepersNeededforGoal2 = "keeper-Nick";
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
