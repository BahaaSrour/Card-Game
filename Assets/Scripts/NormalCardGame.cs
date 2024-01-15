using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCardGame : Board
{

    public IRound sequentialRound;
    int theLastRoundWinninngPlayer;


    private void Start()
    {
        theLastRoundWinninngPlayer = 0;
        sequentialRound = GetComponent<IRound>();
    }


    [ContextMenu("Start new Game")]
    public void StartNewGame()
    {
        base.CreateNewTable();
        base.Wazza3Lkroot();
        sequentialRound.initRound(0);
    }


}