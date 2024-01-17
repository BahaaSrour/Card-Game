using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    public ScriptableEvent<int, Card> OnAnimateCard;
    public RectTransform[] sources;
    public RectTransform[] destinations;
    public CardDrawer[] cardDrawer;

    public void AnimateCard(int index,Card card)
    {
        
    }
}
