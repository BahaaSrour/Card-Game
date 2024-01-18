using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class NormalCardGame : Board
{

    public IRound sequentialRound;
    public ScriptableEvent<Card> OnSelectingCard;
    public ScriptableEvent<int, Card> OnAnimateCard;
    public ScriptableEvent OnPlayerRecieveCards;
    public ScriptableEvent OnEndRound;
    public ScriptableEvent<Player[],int> OnEndGameSO;

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
        OnAnimateCard.Fire(sequentialRound._currentTurn, card);
        x++;
        if (x % 4 == 0)
        {
            StartCoroutine(  OnRoundEnds());
        }
        else
        {
            sequentialRound.ChangeTurn();
            players[sequentialRound._currentTurn].StartTurn();
        }
    }

    int rounds = 0;
    IEnumerator OnRoundEnds()
    {
        yield return new WaitForSeconds(3);
        rounds++;
        CalculateWinner();
        if (rounds == 13)
        {
            EndGame();
            yield break;
        }
        selectedCards.Clear();
        sequentialRound.initRound(theLastRoundWinninngPlayer);
        players[sequentialRound._currentTurn].StartTurn();
        OnEndRound.Fire();
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
        selectedCards.Clear();
        theLastRoundWinninngPlayer = (theLastRoundWinninngPlayer + winnerIndex) % 4;


        players[theLastRoundWinninngPlayer].wonRounds++;
    }

    public void EndGame()
    {
        int winnerIndex = 0;
        int highestwinningRoundcount = 0;
        for (int i = 0; i < players.Length; i++)
        {
            //Debug.Log($" Player {i} score is {players[i].wonRounds}");
            if (players[i].wonRounds > highestwinningRoundcount)
            {
                highestwinningRoundcount = players[i].wonRounds;
                winnerIndex = i;
            }
        }
        OnEndGameSO.Fire(players, winnerIndex);
    }
}