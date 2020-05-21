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

    public int drawRule, playRule, limitRule;
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
        else if(string.Compare(str, "rule") == 0)
        {
            type = CardType.RULE;
        }
        KeepersForTheGoal();
        RulesCardsRule();
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
                keepersNeededforGoal2 = "keeper-AJBieszczad";
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
            if(string.Compare(Name, "goal-IDEWar") == 0)
            {
                keepersNeededforGoal1 = "keeper-CLion";
                keepersNeededforGoal2 = "keeper-VisualStudio";
            }
            if(string.Compare(Name, "goal-LanguageOfWizards") == 0)
            {
                keepersNeededforGoal1 = "keeper-pep9";
                keepersNeededforGoal2 = "keeper-PeterSmith";
            }
            if(string.Compare(Name, "goal-OnlineLearning") == 0)
            {
                keepersNeededforGoal1 = "keeper-Zoom";
                keepersNeededforGoal2 = "keeper-MyCI";
            }
            if(string.Compare(Name, "goal-ProjectChoices") == 0)
            {
                keepersNeededforGoal1 = "keeper-Unity";
                keepersNeededforGoal2 = "keeper-AndroidStudio";
            }
            if(string.Compare(Name, "goal-Teamwork") == 0)
            {
                keepersNeededforGoal1 = "keeper-GitHub";
                keepersNeededforGoal2 = "keeper-Unity";
                keepersNeededforGoal3 = "keeper-AndroidStudio";
            }
            if(string.Compare(Name, "goal-TheRivalry") == 0)
            {
                keepersNeededforGoal1 = "keeper-AMD";
                keepersNeededforGoal2 = "keeper-TimMattson";
            }
        }
    }

    public void RulesCardsRule()
    {
        if(isRule())
        {
            if(string.Compare(Name, "rule-Draw2") == 0)
            {
                drawRule = 2;
                playRule = -1;// null
                limitRule = -1;//null
            }
            if(string.Compare(Name, "rule-Draw3") == 0)
            {
                drawRule = 3;
                playRule = -1;// null
                limitRule = -1;//null
            }
            if(string.Compare(Name, "rule-Play2") == 0)
            {
                drawRule = -1; //null
                playRule = 2;
                limitRule = -1;//null
            }
            if(string.Compare(Name, "rule-Play3") == 0)
            {
                drawRule = -1; //null
                playRule = 3;
                limitRule = -1;//null
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
    public int getDrawRules()
    {
        return drawRule;
    }
    public int getPlayRule()
    {
        return playRule;
    }
    public bool isPlayCard()
    {
        if(playRule > 0)
            return true;
        else
            return false;
    }
    public int getLimitRule()
    {
        return limitRule;
    }
}
