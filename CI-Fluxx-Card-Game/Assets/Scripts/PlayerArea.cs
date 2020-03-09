using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{
    public Keeper[] keepersPlayed;
    public Card[] playerHand;
    public int playerId;
    public int HAND_LIMIT = 10;

    

    public void createHand(int HAND_LIMIT)
    {
        playerHand = new Card[HAND_LIMIT];
        drawCards();
    }

    public void playCard()
    {

    }

    public void drawCards() // pass in the deck here
    {
        int drawRules = 2;  // get current draw rules here

 
        for(int i = 0; i <= drawRules; i++)
        {
            playerHand[i] = new Card();     // draw from deck passed in
        }
    }

    public Card[] getCardsInPlay()
    {
        return playerHand;
    }




}
