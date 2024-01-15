using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRound
{
    void initRound(int startTurn=0);
    void ChangeTurn();
    public int _currentTurn { get; }
}
