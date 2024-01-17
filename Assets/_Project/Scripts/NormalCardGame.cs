using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
        players[sequentialRound._currentTurn].StartTurn();
    }
    int x = 0;
    public void AddCardToTheBoard(Card card)
    {
        selectedCards.Add(card);
        x++;
        if (x % 4 == 0)
        {
            OnRoundEnds();
        }
        else
        {
            sequentialRound.ChangeTurn();
            players[sequentialRound._currentTurn].StartTurn();
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
        CalculateWinner();
        selectedCards.Clear();
        sequentialRound.initRound(theLastRoundWinninngPlayer);
        players[sequentialRound._currentTurn].StartTurn();
    }

    public override void CalculateWinner()
    {
        int winnerIndex = 0;
        var highestnumber = (((int)selectedCards[winnerIndex]._suit) * 13) + (int)selectedCards[winnerIndex]._rank;
        for (int i = 0; i < 4; i++)
        {
            var x = (((int)selectedCards[i]._suit) * 13) + (int)selectedCards[i]._rank;
            if (highestnumber < x)
            {
                winnerIndex = i;
                highestnumber = x;
            }
        }
    }
}