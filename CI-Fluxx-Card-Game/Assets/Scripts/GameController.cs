using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cards;
    public Transform transform_Deck, transform_Goal, transform_Rules;
    public List<GameObject> listCard = new List<GameObject>(32);
    public List<GameObject> listGoal;
    public List<GameObject> Rules;
    public GameObject playerZone;
    public GameObject enemyZone;
    public GameObject keeperArea;
    public GameObject enemyKeeperArea;
    public GameObject GameOverUI;
    public GameObject GameOverLoseUI;
    private bool goalMeet;
    private bool goalMeet2;
    private bool EnemygoalMet;
    private bool EnemygoalMet2;
    private int NumberOfKeepersInKeeperArea;
    private int NumberOfKeepersInKeeperAreaForEnemy;
    private bool gameOver;
    private bool turnOver;
    public int currentDrawCardsRule;
    public int currentPlayCardsRule;
    // Start is called before the first fra`    me update
    void Start()
    {
        InstanceCard();
        //keeperArea = GameObject.Find("Keepers");
        //enemyKeeperArea = GameObject.Find("Enemey Keepers");
        goalMeet = false;
        goalMeet2 = false;
        EnemygoalMet = false;
        EnemygoalMet2 = false;
        gameOver = false;
        currentDrawCardsRule = 1;
        currentPlayCardsRule = 1;
    }

    // Update is called once per frame
    void Update()
    {
    
            NumberOfKeepersInKeeperArea = keeperArea.transform.childCount;
            NumberOfKeepersInKeeperAreaForEnemy = enemyKeeperArea.transform.childCount;
            if(NumberOfKeepersInKeeperArea != 0 && gameOver == false)
            {
                CheckIfGoalIsMet();
            }
            if(NumberOfKeepersInKeeperAreaForEnemy != 0 && gameOver == false)
            {
                CheckIfGoalIsMetForEnemy();
            }
    }
    public void InstanceCard()
    {
        for (int i = 0; i < LoadDeck.instance.deckArr.Length; i++)
        {
            GameObject _cards = Instantiate(cards, transform_Deck.position, Quaternion.identity);
            _cards.transform.SetParent(transform_Deck, false);
            _cards.GetComponent<UICards>().image_cards.sprite = LoadDeck.instance.deckArr[i];
            listCard.Add(_cards);
        }
        for (int i = 0; i < LoadDeck.instance.goalArr.Length; i++)
        {
            GameObject _goals = Instantiate(cards, transform_Goal.position, Quaternion.identity);
            _goals.GetComponent<UICards>().image_cards.sprite = LoadDeck.instance.goalArr[i];
            listGoal.Add(_goals);
        }
        
        GameObject _rules = Instantiate(cards, transform_Rules.position, Quaternion.identity);
        _rules.GetComponent<UICards>().image_cards.sprite = LoadDeck.instance.basicRules;
        Rules.Add(_rules);

        StartCoroutine(SplitCards());
    }

    IEnumerator SplitCards()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            int rdPlayer = Random.Range(0,listCard.Count-1);
            listCard[rdPlayer].transform.SetParent(playerZone.transform, true);
            //iTween.MoveTo(listCard[rdPlayer], iTween.Hash("position", playerZone, "easeType", "Linear", "loopType", "none", "time", 0.9f));
            iTween.RotateBy(listCard[rdPlayer], iTween.Hash("y", 0.5f, "easeType", "Linear", "loopType", "none", "time", 0.2f));
            //yield return new WaitForSeconds(0.25f);
            listCard[rdPlayer].GetComponent<UICards>().gob_FrontCard.SetActive(false);
            listCard[rdPlayer].GetComponent<UICards>().SetIsThisCardYours(true);
            listCard.RemoveAt(rdPlayer);

        }
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            int rdAI = Random.Range(0,listCard.Count-1);
            listCard[rdAI].transform.SetParent(enemyZone.transform, true);
            //iTween.MoveTo(listCard[rdAI], iTween.Hash("position", enemyZone, "easeType", "Linear", "loopType", "none", "time", 0.4f));
            iTween.RotateBy(listCard[rdAI], iTween.Hash("y", 0.5f, "easeType", "Linear", "loopType", "none", "time", 0.4f));
            yield return new WaitForSeconds(0.25f);
            listCard[rdAI].GetComponent<UICards>().gob_FrontCard.SetActive(false);
            listCard.RemoveAt(rdAI);
        }
        yield return new WaitForSeconds(0.5f);
        listGoal[0].transform.SetParent(transform_Goal, false);
        listGoal[0].GetComponent<UICards>().gob_FrontCard.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        Rules[0].transform.SetParent(transform_Rules, false);
        Rules[0].GetComponent<UICards>().gob_FrontCard.SetActive(false);


    }
    public void CheckIfGoalIsMet()
    {
        for (int i = 0; i < NumberOfKeepersInKeeperArea; i++)
        {
            if(string.Compare(listGoal[0].GetComponent<UICards>().keepersNeededforGoal1, keeperArea.transform.GetChild(i).gameObject.GetComponent<UICards>().Name) == 0)
            {
                goalMeet = true;
            }
            if(string.Compare(listGoal[0].GetComponent<UICards>().keepersNeededforGoal2, keeperArea.transform.GetChild(i).gameObject.GetComponent<UICards>().Name) == 0)
            {
                goalMeet2 = true;
            }
            if(goalMeet == true && goalMeet2 == true)
            {
                Debug.Log("u won");
                goalMeet = false;
                gameOver = true;
                GameOverUI.SetActive(true);
            }
        }
    }

    public void CheckIfGoalIsMetForEnemy()
    {
        for (int i = 0; i < NumberOfKeepersInKeeperAreaForEnemy; i++)
        {
            if(string.Compare(listGoal[0].GetComponent<UICards>().keepersNeededforGoal1, enemyKeeperArea.transform.GetChild(i).gameObject.GetComponent<UICards>().Name) == 0)
            {
                EnemygoalMet = true;
            }
            if(string.Compare(listGoal[0].GetComponent<UICards>().keepersNeededforGoal2, enemyKeeperArea.transform.GetChild(i).gameObject.GetComponent<UICards>().Name) == 0)
            {
                EnemygoalMet2 = true;
            }
            if(EnemygoalMet == true && EnemygoalMet2 == true)
            {
                Debug.Log("enemey won");
                gameOver = true;
                GameOverLoseUI.SetActive(true);
            }
        }
    }
    public void drawCards(int cardsToDraw)
    {

    }
    public void isTurnOver()
    {

    }
    
}
