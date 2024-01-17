using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCardGame : Board
{

    public IRound sequentialRound;
    public ScriptableEvent<Card> OnSelectingCard;
    public ScriptableEvent OnPlayerRecieveCards;

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
        OnPlayerRecieveCards.Fire();
        sequentialRound.initRound(0);
    }
    int x=0;
    public void AddCardToTheBoard(Card card)
    {
        selectedCards.Add(card);
        sequentialRound.ChangeTurn();
        players[sequentialRound._currentTurn].StartTurn();
        x++;
        if(x%4==0) 
        {
            OnRoundEnds();
        }
    }

    int rounds = 0;
    void OnRoundEnds()
    {
        rounds++;
        if (rounds == 13)
        {
            Debug.Log("ended");
            return;
        }
        Debug.Log("Round Ended");
        //(((int)card._suit) * 13) + (int)card._rank
    }
}