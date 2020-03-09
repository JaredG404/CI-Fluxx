using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardScript : MonoBehaviour
{
    public bool Goal() => true;

    public static void CreateDeck()
    {
        //Deck theDeck = new Deck(20);
        //theDeck.reshuffle();


    }
    public void CreatePlayer()
    {
        for (int k = 0; k < numberOfPlayers; k++)
        {
            //Player player = new Player(ID: k+1);
            // player.hand(0);
        }

    }

    int numberOfPlayers = 2;
    
    bool isGameGoing = true;
    // Start is called before the first frame update
    void Start()
    {


        // if(Deck.AvailableCards <= CardsDrawn) => Deck.Reshuffle();

        //playerArea.AddtoHand(playerID);

        while (isGameGoing)
        {
            //play(playerID);
            //playerID = (playerID + 1) % NumberOfPlayers;


            isGameGoing = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
