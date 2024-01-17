using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUi : MonoBehaviour
{
    public ScriptableEvent<List<Card>> OnDrawPlayerCards;
    public Transform container;
    public GameObject cardbutton;

    private void Awake()
    {
        OnDrawPlayerCards.addListener(CraeteCardsOfrPlayrt);
    }
    public void CraeteCardsOfrPlayrt(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            var btn = Instantiate(cardbutton, container);
            btn.GetComponent<CardDrawer>().DrawCard(cards[i]);
        }
    }
}
