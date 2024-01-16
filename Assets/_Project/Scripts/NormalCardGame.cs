using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCardGame : Board
{

    public IRound sequentialRound;
    public ScriptableEvent<Card> OnSelectingCard;

    int theLastRoundWinninngPlayer = 0;
    private void Start()
    {
        theLastRoundWinninngPlayer = 0;
        OnSelectingCard.addListener(AddCardToTheBoard);

        //StartNewGame();
    }


    [ContextMenu("Start new Game")]
    public override void StartNewGame()
    {
        sequentialRound = GetComponent<IRound>();
        CreateNewTable();
        Wazza3Lkroot();
        sequentialRound.initRound(0);
    }

    public void AddCardToTheBoard(Card card)
    {
        selectedCards.Add(card);
        sequentialRound.ChangeTurn();
        players[sequentialRound._currentTurn].StartTurn();
    }
}