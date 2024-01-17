using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public List<Card> myCards;
    public ScriptableEvent<Card> OnSelectingCard;
    public ScriptableEvent OnPlayerRecieveCards;
    public int wonRounds { set; get; }
    private void Awake()
    {
        myCards = new List<Card>();
        OnPlayerRecieveCards.addListener(SortMyCards);
    }
    public void GetCard(Card card)
    {
        myCards.Add(card);
    }
    public void SelectCardToPlay(Card card)
    {
        if (myCards.Contains(card))
        {
            card.DebugCard();
            RemoveCard(card);
            OnSelectingCard.Fire(card);
        }
    }

    [ContextMenu("Debug cards")]
    public void debugMyCards()
    {
        foreach (Card card in myCards)
        {
            card.DebugCard();
        }
    }

    void RemoveCard(Card card)
    {
        myCards.Remove(card);
    }
    public abstract void StartTurn();

    CompareCardDesending compareCardDesending;
    public void SortMyCards()
    {
        compareCardDesending = new CompareCardDesending();
        myCards.Sort(compareCardDesending);
    }
}
