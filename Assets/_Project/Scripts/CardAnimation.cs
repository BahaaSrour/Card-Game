using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    public ScriptableEvent<int, Card> OnAnimateCard;
    public RectTransform[] sources;
    public RectTransform[] destinations;
    public CardDrawer[] cardDrawer;
    public ScriptableEvent OnEndRound;

    private void Start()
    {
        OnAnimateCard.addListener(AnimateCard);
        OnEndRound.addListener(ClearCards);
    }
    public void AnimateCard(int index, Card card)
    {
        cardDrawer[index].rectTransform.anchoredPosition = new Vector3(0, 0, 0);
        cardDrawer[index].gameObject.SetActive(true);
        cardDrawer[index].DrawCard(card);
        cardDrawer[index].rectTransform.DOMove(destinations[index].position, .8f);
    }

    public void ClearCards()
    {
        for (int i = 0; i < 4; i++)
        {

            cardDrawer[i].gameObject.SetActive(false);
        }

    }
}
