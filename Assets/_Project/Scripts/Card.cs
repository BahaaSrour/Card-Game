using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Card
{
    public CardRank _rank;
    public CardSuit _suit;
    public int cardValue;
    public Card(CardRank rank, CardSuit shape)
    {
        _rank = rank;
        _suit = shape;
        cardValue = ((int)_suit * 13) + (int)_rank;
    }
    public bool Equals(Card other)
    {
        return this._rank == other._rank && this._suit == other._suit;
    }
    public bool CheckBiggerThan(Card _1st, Card _2nd)
    {
        if (_1st._suit > _2nd._suit)
            return true;
        else if ((_1st._suit == _2nd._suit))
            return   (_1st._rank > _2nd._rank);
        return false;
    }

    public void DebugCard()
    {
        Debug.Log($" suit ={_rank} ,{_suit}");
    }

}

public class CompareCardDesending : IComparer<Card>
{

    public int Compare(Card x, Card y)
    {
        return y.cardValue - x.cardValue;
    }
}
public enum CardRank
{
    Two ,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace,
}
public enum CardSuit
{
    Clubs ,
    Diamonds,
    Hearts,
    Spades
}

