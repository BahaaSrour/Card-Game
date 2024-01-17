using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class HumanPlayer : Player
{
    bool isPLayerTurn;
    public ScriptableEvent OnPlayerRecieveCards;
    public ScriptableEvent<List<Card>> OnDrawPlayerCards;
    private void Awake()
    {
        OnPlayerRecieveCards.addListener(DrawCardsInUI);
    }
    public override void StartTurn()
    {

    }

    public void DrawCardsInUI()
    {
       OnDrawPlayerCards.Fire(myCards);
    }
}
