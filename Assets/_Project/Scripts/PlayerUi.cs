using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    public ScriptableEvent<List<Card>> OnDrawPlayerCards;
    public ScriptableEvent PlayerTurn;
    public Transform container;
    public GameObject cardbutton;
    public Image PlayerBlocker;

    private void Awake()
    {
        OnDrawPlayerCards.addListener(CraeteCardsOfrPlayrt);
        PlayerTurn.addListener(BlockHumanPlayer);
    }
    public void CraeteCardsOfrPlayrt(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            var btn = Instantiate(cardbutton, container);
            btn.GetComponent<CardDrawer>().DrawCard(cards[i]);
        }
    }

    void BlockHumanPlayer()
    {
        Debug.Log("Called");
        PlayerBlocker.enabled = !PlayerBlocker.enabled;
    }
}
