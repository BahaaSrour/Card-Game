using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{
    public override void StartTurn()
    {
        Debug.Log(gameObject.name);
        SelectCardToPlay(myCards[0]);
    }
}
