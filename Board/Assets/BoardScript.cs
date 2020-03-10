using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardScript : MonoBehaviour
{
    // readonly = Final
    readonly static int MAX_HAND_SIZE;
    readonly static int MAX_PLAY_AREA_SIZE;


    static int currentPlayer;
    static int playNumber;
    static int drawNumber;

    int numberOfPlayers = 2; //2 for now until we get number from other class

    bool isGameGoing = true;



    public bool Goal() => true;

    public static void CreateDeck(int numberOfCards)
    {
        //Deck theDeck = new Deck(20);
        //theDeck.reshuffle();


    }
    public void CreatePlayer(int playerID)
    {
        for (int k = 0; k < numberOfPlayers; k++)
        {
            //Player player = new Player(ID: playerID);
            // player.hand(0);
        }

    }

 
    
   
    // Start is called before the first frame update
    void Start()
    {


        // if(Deck.AvailableCards <= CardsDrawn) => Deck.Reshuffle();

        //playerArea.AddtoHand(playerID);

        while (isGameGoing)
        {
            //play(playerID);
            //playerID = (playerID + 1) % NumberOfPlayers;

            //isGameGoing = Goal.isMet();
            isGameGoing = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
