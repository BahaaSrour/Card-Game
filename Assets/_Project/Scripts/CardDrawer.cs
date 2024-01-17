using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDrawer : MonoBehaviour
{
    public Image image;
    public Cardshape cardshape;
    public void DrawCard(Card card)
    {
        image.sprite = cardshape.gameCards[(((int)card._suit)*13)+(int)card._rank].sprite;
    }
}
