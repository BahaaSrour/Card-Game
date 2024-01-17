using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class HumanPlayer : Player
{
    bool isPLayerTurn;
    public ScriptableEvent OnPlayerRecieveCards;

    public ScriptableEvent<List<Card>> OnDrawPlayerCards;
    public ScriptableEvent<Card> OnUICardSelected;
    private void Awake()
    {
        OnPlayerRecieveCards.addListener(DrawCardsInUI);
        OnUICardSelected.addListener(SelectCardToPlay);
    }
    public override void StartTurn()
    {

    }

    public void DrawCardsInUI()
    {
       OnDrawPlayerCards.Fire(myCards);
    }
}
