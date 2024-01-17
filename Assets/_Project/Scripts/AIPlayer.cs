using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : Player
{
    public override void StartTurn()
    {
        StartCoroutine(playCard());
    }
    IEnumerator playCard()
    {
        yield return new WaitForSeconds(3f);
        //Debug.Log(gameObject.name);
        SelectCardToPlay(myCards[0]);
    }
}
