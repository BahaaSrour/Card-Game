using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialRound : MonoBehaviour, IRound
{
    int _numberOfPlayers=4;
    public int _currentTurn { get; private set; }

    public void initRound(int startTurn)
    {
        _currentTurn = startTurn;
    }

    public void ChangeTurn()
    {
        _currentTurn = (_currentTurn + 1) % _numberOfPlayers;

    }
}
