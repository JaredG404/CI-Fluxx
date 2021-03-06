﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public enum GameState
    {
        GameStart,
        PlayerTurn,
        EnemeyTurn,
        GameIsOver

    }

    public static GameController currentGame;
    public GameObject cards;
    public Transform transform_Deck, transform_Goal, transform_Rules, transform_discard, transform_RulePlay;
    public List<GameObject> listCard = new List<GameObject>(32);
    public List<GameObject> listGoal;
    public List<GameObject> Rules;
    public GameObject playerZone;
    public GameObject enemyZone;
    public GameObject keeperArea;
    public GameObject enemyKeeperArea;
    public GameObject GameOverUI;
    public GameObject GameOverLoseUI;
    public GameObject currentGoal;
    public GameObject menu;
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
    public GameState gameState;
    public int cardsPlayed;
    public int enemeyCardsPlayed;
    public GameObject playerTurn, enmeyTurn;

    public bool clickToggle;
    // Start is called before the first fra`    me update
    void Start()
    {
        //InstanceCard();
        //keeperArea = GameObject.Find("Keepers");
        //enemyKeeperArea = GameObject.Find("Enemey Keepers");
        goalMeet = false;
        goalMeet2 = false;
        EnemygoalMet = false;
        EnemygoalMet2 = false;
        gameState = GameState.GameStart;
        currentDrawCardsRule = 1;
        currentPlayCardsRule = 1;
        cardsPlayed = 0;
        enemeyCardsPlayed = 0;
        clickToggle = false;
        StartCoroutine(GameFlow());    
    }

    private void Awake()
    {
        if(currentGame == null)
        {
            DontDestroyOnLoad(gameObject);
            currentGame = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameState);
            NumberOfKeepersInKeeperArea = keeperArea.transform.childCount;
            NumberOfKeepersInKeeperAreaForEnemy = enemyKeeperArea.transform.childCount;
            if(NumberOfKeepersInKeeperArea != 0 && gameState != GameState.GameIsOver)
            {
                CheckIfGoalIsMet();
            }
            if(NumberOfKeepersInKeeperAreaForEnemy != 0 && gameState != GameState.GameIsOver)
            {
                CheckIfGoalIsMetForEnemy();
            }
    }
  

    IEnumerator SplitCards()
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
            _goals.transform.SetParent(transform_Deck, false);
            _goals.GetComponent<UICards>().image_cards.sprite = LoadDeck.instance.goalArr[i];
            listGoal.Add(_goals);
            listCard.Add(_goals);
        }
        
        for (int i = 0; i < LoadDeck.instance.rulesArr.Length; i++)
        {
            GameObject _Rules = Instantiate(cards, transform_Rules.position, Quaternion.identity);
            _Rules.transform.SetParent(transform_Deck, false);
            _Rules.GetComponent<UICards>().image_cards.sprite = LoadDeck.instance.rulesArr[i];
            listCard.Add(_Rules);
        }

        GameObject _rules = Instantiate(cards, transform_Rules.position, Quaternion.identity);
        _rules.GetComponent<UICards>().image_cards.sprite = LoadDeck.instance.basicRules;
        Rules.Add(_rules);
        Rules.Add(_rules);


        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            int rdPlayer = Random.Range(0,listCard.Count-1);
            listCard[rdPlayer].transform.SetParent(playerZone.transform, true);
            //iTween.MoveTo(listCard[rdPlayer], iTween.Hash("position", playerZone, "easeType", "Linear", "loopType", "none", "time", 0.9f));
            iTween.RotateBy(listCard[rdPlayer], iTween.Hash("y", 0.5f, "easeType", "Linear", "loopType", "none", "time", 0.4f));
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
            //yield return new WaitForSeconds(0.25f);
            listCard[rdAI].GetComponent<UICards>().gob_FrontCard.SetActive(true);
            listCard.RemoveAt(rdAI);
        }
        // picks random goal in beginning of game
        yield return new WaitForSeconds(0.5f);
        int randomGoalIndex = Random.Range(0, listCard.Count - 1);
        while(listCard[randomGoalIndex].GetComponent<UICards>().isGoal() == false)
        {
            randomGoalIndex = Random.Range(0, listCard.Count - 1);
        }
        currentGoal = listCard[randomGoalIndex];
        listCard[randomGoalIndex].transform.SetParent(transform_Goal, false);
        listCard[randomGoalIndex].GetComponent<UICards>().gob_FrontCard.SetActive(false);
        listCard.RemoveAt(randomGoalIndex);
        

        yield return new WaitForSeconds(0.5f);
        Rules[0].transform.SetParent(transform_Rules, false);
        Rules[0].GetComponent<UICards>().gob_FrontCard.SetActive(false);
        gameState = GameState.PlayerTurn;
        StartCoroutine(GameFlow());
    }


    public void CheckIfGoalIsMet()
    {

        for (int i = 0; i < NumberOfKeepersInKeeperArea; i++)
        {
            if(string.Compare(currentGoal.GetComponent<UICards>().keepersNeededforGoal1, keeperArea.transform.GetChild(i).gameObject.GetComponent<UICards>().Name) == 0)
            {
                goalMeet = true;
            }
            if(string.Compare(currentGoal.GetComponent<UICards>().keepersNeededforGoal2, keeperArea.transform.GetChild(i).gameObject.GetComponent<UICards>().Name) == 0
                || string.Compare(currentGoal.GetComponent<UICards>().keepersNeededforGoal3, keeperArea.transform.GetChild(i).gameObject.GetComponent<UICards>().Name) == 0
                || string.Compare(currentGoal.GetComponent<UICards>().keepersNeededforGoal4, keeperArea.transform.GetChild(i).gameObject.GetComponent<UICards>().Name) == 0
                || string.Compare(currentGoal.GetComponent<UICards>().keepersNeededforGoal5, keeperArea.transform.GetChild(i).gameObject.GetComponent<UICards>().Name) == 0)
            {
                goalMeet2 = true;
            }
            if(goalMeet == true && goalMeet2 == true)
            {
                Debug.Log("u won");
                goalMeet = false;
                gameState = GameState.GameIsOver;
                GameOverUI.SetActive(true);
                playerTurn.SetActive(false);
                enmeyTurn.SetActive(false);
                StartCoroutine(waiter());
                //Application.Quit();
            }
        }
        //Debug.Log("goal for player not met");
        goalMeet = false; 
        goalMeet2 = false;
    }

    public void CheckIfGoalIsMetForEnemy()
    {
        for (int i = 0; i < NumberOfKeepersInKeeperAreaForEnemy; i++)
        {
            if(string.Compare(currentGoal.GetComponent<UICards>().keepersNeededforGoal1, enemyKeeperArea.transform.GetChild(i).gameObject.GetComponent<UICards>().Name) == 0)
            {
                EnemygoalMet = true;
            }
            if(string.Compare(currentGoal.GetComponent<UICards>().keepersNeededforGoal2, enemyKeeperArea.transform.GetChild(i).gameObject.GetComponent<UICards>().Name) == 0
                || string.Compare(currentGoal.GetComponent<UICards>().keepersNeededforGoal3, enemyKeeperArea.transform.GetChild(i).gameObject.GetComponent<UICards>().Name) == 0
                || string.Compare(currentGoal.GetComponent<UICards>().keepersNeededforGoal4, enemyKeeperArea.transform.GetChild(i).gameObject.GetComponent<UICards>().Name) == 0
                || string.Compare(currentGoal.GetComponent<UICards>().keepersNeededforGoal5, enemyKeeperArea.transform.GetChild(i).gameObject.GetComponent<UICards>().Name) == 0)
            {
                EnemygoalMet2 = true;
            }
            if(EnemygoalMet == true && EnemygoalMet2 == true)
            {
                Debug.Log("enemey won");
                gameState = GameState.GameIsOver;
                GameOverLoseUI.SetActive(true);
                playerTurn.SetActive(false);
                enmeyTurn.SetActive(false);
                StartCoroutine(waiter());
                //Application.Quit();
                
            }
        }
        EnemygoalMet = false;
        EnemygoalMet2 = false;
    }

    public IEnumerator waiter()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("load main menu");
        playerTurn.SetActive(false);
        enmeyTurn.SetActive(false);
        GameOverLoseUI.SetActive(false);
        GameOverUI.SetActive(false);
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator drawCards(int cardsToDraw)
    {
        for (int i = 0; i < cardsToDraw; i++)
        {
            if(cardsToDraw == 1)
            {
                yield return new WaitForSeconds(2f);
            }
            else{
                yield return new WaitForSeconds(.5f);
            }
            int rdPlayer = Random.Range(0,listCard.Count-1);
            listCard[rdPlayer].transform.SetParent(playerZone.transform, true);
            iTween.RotateBy(listCard[rdPlayer], iTween.Hash("y", 0.5f, "easeType", "Linear", "loopType", "none", "time", 0.2f));
            listCard[rdPlayer].GetComponent<UICards>().gob_FrontCard.SetActive(false);
            listCard[rdPlayer].GetComponent<UICards>().SetIsThisCardYours(true);
            listCard.RemoveAt(rdPlayer);
        }
        playerTurn.SetActive(true);
        enmeyTurn.SetActive(false);
    }
    public IEnumerator drawCardsForEnemy(int cardsToDraw)
    {
        for (int i = 0; i < cardsToDraw; i++)
        {
            if(cardsToDraw == 1)
            {
                yield return new WaitForSeconds(2f);
            }
            else{
                yield return new WaitForSeconds(.5f);
            }
            int AIRdCard = Random.Range(0,listCard.Count-1);
            listCard[AIRdCard].transform.SetParent(enemyZone.transform, true);
            iTween.RotateBy(listCard[AIRdCard], iTween.Hash("y", 0.5f, "easeType", "Linear", "loopType", "none", "time", 0.2f));
            listCard[AIRdCard].GetComponent<UICards>().gob_FrontCard.SetActive(true);
            listCard[AIRdCard].GetComponent<UICards>().SetIsThisCardYours(false);
            listCard.RemoveAt(AIRdCard);
        }
        playerTurn.SetActive(false);
        enmeyTurn.SetActive(true);
    }
    private IEnumerator GameFlow()
    {
        
        switch(gameState)
        {
            case GameState.GameStart:
            {
                Debug.Log("start");
                StartCoroutine(SplitCards());
                break;
            }
            case GameState.PlayerTurn:
            {
                if(currentPlayCardsRule > 1)
                {
                    yield return new WaitForSeconds(4f);
                }
                yield return new WaitForSeconds(3f);
                //deal the number of cards corresponding to the current rules and play the number of cards corresponding to the rules
                Debug.Log("playTurn");
                StartCoroutine(drawCards(currentDrawCardsRule));
                StartCoroutine(waitForTurn());
                break;
            }
            case GameState.EnemeyTurn:
            {
                //deal the number of cards corresponding to the current rules to the enmey and play the number of cards corresponding to the rules to the enemy
                Debug.Log("enemys turn");
                StartCoroutine(drawCardsForEnemy(currentDrawCardsRule));
                StartCoroutine(AIPlay());
                gameState = GameState.PlayerTurn;
                //currentGame.enemeyCardsPlayed = 0;
                StartCoroutine(GameFlow());
                break;
            }
        }
    }

    IEnumerator waitForTurn()
    {
        clickToggle = true;
        //10 second timer 
        for( float timer = 60 ; timer >= 0 ; timer -= Time.deltaTime )
        {
            if(currentGame.cardsPlayed >= currentPlayCardsRule)
            {
                Debug.Log("played  turn over hopefully!");
                clickToggle = false;
                gameState = GameState.EnemeyTurn;
                currentGame.cardsPlayed = 0;
                CheckIfGoalIsMet();
                StartCoroutine(GameFlow());
                yield break;
            }
            yield return null ;
        }
        // Debug.Log("turn over sorry mate!");
        // gameState = GameState.EnemeyTurn;
        // StartCoroutine(GameFlow());
    }

    IEnumerator AIPlay()
    {

        if(currentDrawCardsRule == 1)
        {
            yield return new WaitForSeconds(4f);
        }
        else{
            yield return new WaitForSeconds(2.5f);
        }
        for (int i = 0; i < currentPlayCardsRule; i++)
        {
            int AICardPlayed = Random.Range(0, enemyZone.transform.childCount - 1);

            GameObject tempCard = enemyZone.transform.GetChild(AICardPlayed).gameObject;

            if(enemyZone.transform.GetChild(AICardPlayed).GetComponent<UICards>().isGoal() == true)
            {
                //GameObject tempCard = enemyZone.transform.GetChild(AICardPlayed).gameObject;
                transform_Goal.GetChild(0).transform.SetParent(transform_discard, false);
                currentGoal.GetComponent<UICards>().gob_FrontCard.SetActive(true); 
                enemyZone.transform.GetChild(AICardPlayed).SetParent(transform_Goal, false);
                currentGoal = tempCard;
                currentGoal.transform.Rotate(0,-180,0);
            }
            else if(enemyZone.transform.GetChild(AICardPlayed).GetComponent<UICards>().isRule() == true)
            {
                if(tempCard.GetComponent<UICards>().isPlayCard() == true)
                {
                    Rules[0].GetComponent<UICards>().gob_FrontCard.SetActive(true);
                    Rules[0].transform.SetParent(transform_discard, false);
                    Rules[0] = tempCard;
                    tempCard.transform.SetParent(transform_Rules, false);
                }
                else{
                    Rules[1].GetComponent<UICards>().gob_FrontCard.SetActive(true);
                    Rules[1].transform.SetParent(transform_discard, false);
                    Rules[1] = tempCard;
                    tempCard.transform.SetParent(transform_RulePlay, false);
                }
                
                int play, draw;
                play = tempCard.GetComponent<UICards>().getPlayRule();
                draw = tempCard.GetComponent<UICards>().getDrawRules();

                if(play > 1)
                {
                    currentPlayCardsRule = play;
                    Debug.Log("play "+ play);
                }
                if(draw > 1)
                {
                    currentDrawCardsRule = draw;
                    Debug.Log("draw "+ draw);
                }
                tempCard.transform.Rotate(0, -180, 0);
            }
            else{
                enemyZone.transform.GetChild(AICardPlayed).SetParent(enemyKeeperArea.transform, false);
            }
            tempCard.GetComponent<UICards>().gob_FrontCard.SetActive(false);
            CheckIfGoalIsMetForEnemy();
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(1f);
    }
}
