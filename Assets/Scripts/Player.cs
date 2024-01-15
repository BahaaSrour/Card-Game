using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Card> myCards;

    private void Start()
    {
        myCards = new List<Card>();
    }

    public void GetCard(Card card)
    {
        
        myCards.Add(card);
    }

    public Card SelectCardToPlay(Card card)
    {
        if (myCards.Contains(card))
            return card;

        //TODO:: player played Unvalid car need to play another card
            return null;
    }

    [ContextMenu("Debug cards")]
    public void debugMyCards()
    {
        foreach (Card card in myCards) 
        {
            card.DebugCard();
        }
    }
}
