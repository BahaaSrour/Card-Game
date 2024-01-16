using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public List<Card> myCards;
    public ScriptableEvent<Card> OnSelectingCard;
    private void Start()
    {
        myCards = new List<Card>();
    }
    public void GetCard(Card card)
    {
        myCards.Add(card);
    }
    public void SelectCardToPlay(Card card)
    {
        if (myCards.Contains(card))
            OnSelectingCard.Fire(card);
    }

    [ContextMenu("Debug cards")]
    public void debugMyCards()
    {
        foreach (Card card in myCards)
        {
            card.DebugCard();
        }
    }
    public abstract void StartTurn();
}
