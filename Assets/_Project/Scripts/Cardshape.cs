using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/ Cards Shape")]
public class Cardshape : ScriptableObject

{

    public cardshapes[] gameCards = new cardshapes[52];
    private void Reset()
    {
        int i = 0; 


        foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
        {
            foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
            {
                gameCards[i].rank = rank;
                gameCards[i].suit = suit;
                i++;
            }
        }
    }
}

[System.Serializable]
public struct cardshapes
{
    public CardRank rank;
    public CardSuit suit;
    public Sprite sprite;
}
