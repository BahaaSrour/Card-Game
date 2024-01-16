using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] public List<Card> cards = new List<Card>();
    //test
    //void Start()
    //{
    //    CreateTable();
    //    LogcCardList();
    //    ShuffleCards();
    //    Debug.Log("--------------- '\n'+----------------- '\n-------------'");
    //    LogcCardList();
    //}

    public void CreateTable()
    {
        foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
        {
            foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
            {
                cards.Add(new Card(rank, suit));
            }
        }
    }
    public int Count
    {
        get { return cards.Count; }
    }
    public bool IsEmpty
    {
        get { return cards.Count == 0; }
    }
    public void ShuffleCards()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }
    public Card TakeTopCard()
    {
        Card topCard = null;
        if (cards.Count != 0)
        {
            topCard = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
        }
        return topCard;
    }
    void LogcCardList()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Debug.Log($"card number  {i}  suit ={cards[i]._rank} ,{cards[i]._suit}");
        }
    }
}
