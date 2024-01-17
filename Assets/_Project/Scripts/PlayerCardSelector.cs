using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardSelector : MonoBehaviour
{
    public CardDrawer cardDrawer;
    public ScriptableEvent<Card> OnUICardSelected;

    public void OncardSelect()
    {
        OnUICardSelected.Fire(cardDrawer._card);
        gameObject.SetActive(false);
    }
}
