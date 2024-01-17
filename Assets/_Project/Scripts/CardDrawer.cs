using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDrawer : MonoBehaviour
{
    public RectTransform rectTransform;

    public Image image;
    public Cardshape cardshape;
    public Card _card { get; private set; }

    private void Start()
    {
        rectTransform=GetComponent<RectTransform>();
    }
    public void DrawCard(Card card)
    {
        _card = card;   
        image.sprite = cardshape.gameCards[(((int)card._suit)*13)+(int)card._rank].sprite;
    }
}
