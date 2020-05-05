using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClickMove : MonoBehaviour
{

    public GameObject keeperArea;
    public GameObject enemyKeeperArea;
    public int cardsPlayed;
    // Start is called before the first frame update
    void Start()
    {
        keeperArea = GameObject.Find("Keepers");
        enemyKeeperArea = GameObject.Find("Enemy Keepers");
        cardsPlayed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clicked()
    {
        if(gameObject.GetComponent<UICards>().isKeeper() && gameObject.GetComponent<UICards>().CheckIfThisCardIsYours())
        {
            gameObject.transform.SetParent(keeperArea.transform, false);
            cardsPlayed++;
        }
        if(gameObject.GetComponent<UICards>().isKeeper() && !gameObject.GetComponent<UICards>().CheckIfThisCardIsYours())
        {
            gameObject.transform.SetParent(enemyKeeperArea.transform, false);
        }
    }
}
