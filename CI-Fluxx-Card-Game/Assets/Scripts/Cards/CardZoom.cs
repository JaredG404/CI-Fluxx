using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject keeperArea;
    public GameObject enemyKeeperArea;
    private GameObject zoomCard;
    public GameObject goalArea;

    public void Awake()
    {
        Canvas = GameObject.Find("Canvas");
        keeperArea = GameObject.Find("Keepers");
        enemyKeeperArea = GameObject.Find("Enemy Keepers");
        goalArea = GameObject.Find("Goal");
    }

    public void OnHoverEnter()
    {
        //Debug.Log(Input.mousePosition.x);
        if(gameObject.GetComponent<UICards>().gob_FrontCard.activeSelf == true)
        {
            Debug.Log("This card is flipped over and can't zoom");
        }
        else{
            zoomCard = Instantiate(gameObject);
            zoomCard.transform.SetParent(Canvas.transform, false);
            if((zoomCard.GetComponent<UICards>().isGoal() == true || zoomCard.GetComponent<UICards>().isRule() == true) && zoomCard.GetComponent<UICards>().CheckIfThisCardIsYours() == false)
            {
                Debug.Log("goal herer mate");
                zoomCard.transform.Rotate(0,180,0);
                zoomCard.transform.localPosition = new Vector2(300, 0);
                zoomCard.transform.localScale = new Vector2(2,2);
            }
            else
            {
                zoomCard.transform.localScale = new Vector2(3,3);
                zoomCard.transform.localPosition = new Vector2(Input.mousePosition.x - 550, Input.mousePosition.y - 100);
            }
            RectTransform rect = zoomCard.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(360, 531);
        }
        
    }

    public void OnHoverExit()
    {
        Destroy(zoomCard);
        Debug.Log("zoom destroyed");
    }

    public void clicked()
    {
      
            if(gameObject.GetComponent<UICards>().isKeeper() && gameObject.GetComponent<UICards>().CheckIfThisCardIsYours())
            {
                gameObject.transform.SetParent(keeperArea.transform, false);
                GameController.currentGame.cardsPlayed++;
            }
            if(gameObject.GetComponent<UICards>().isKeeper() && !gameObject.GetComponent<UICards>().CheckIfThisCardIsYours())
            {
                gameObject.transform.SetParent(enemyKeeperArea.transform, false);
                GameController.currentGame.enemeyCardsPlayed++;
            }
    
            if(gameObject.GetComponent<UICards>().isGoal())
            {
                GameController.currentGame.currentGoal.transform.SetParent(GameController.currentGame.transform_discard, false);
                GameController.currentGame.currentGoal.GetComponent<UICards>().gob_FrontCard.SetActive(true);             
                gameObject.transform.SetParent(goalArea.transform, false);
                GameController.currentGame.currentGoal = gameObject;
                GameController.currentGame.currentGoal.transform.Rotate(0,-180,0);
                GameController.currentGame.cardsPlayed++;
            }
            if(gameObject.GetComponent<UICards>().isRule())
            {
                GameController.currentGame.currentDrawCardsRule = gameObject.GetComponent<UICards>().getDrawRules();
                GameController.currentGame.Rules[0].transform.SetParent(GameController.currentGame.transform_discard, false);
                gameObject.transform.SetParent(GameController.currentGame.transform_Rules, false);
                GameController.currentGame.cardsPlayed++;

            }

            gameObject.GetComponent<UICards>().SetIsThisCardYours(false);

        
    }
}
