using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{
    private void Awake()
    {
        OnPlayerRecieveCards.addListener(SortCards);
    }

    private void SortCards()
    {
        for (int i = 0; i < myCards.Count; i++)
        {
            
        }
    }

    public override void StartTurn()
    {
        StartCoroutine(playCard());
    }
    IEnumerator playCard()
    {
        yield return new WaitForSeconds(3f);
        SelectCardToPlay(myCards[0]);
    }
}
