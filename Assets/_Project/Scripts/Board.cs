using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Board : MonoBehaviour
{
    public Player[] players;
    public Table table;
    public int maxCardForPlayer = 13;

    public List<Card> selectedCards = new List<Card>();

    public abstract void StartNewGame();
    public virtual void CreateNewTable()
    {
        table.CreateTable();
        table.ShuffleCards();
    }

    public virtual void Wazza3Lkroot()
    {
        //var x = table.cards.Count / players.Length;
        for (int i = 0; i < players.Length; i++)
        {
            for (int j = 0; j < maxCardForPlayer; j++)
            {
                players[i].GetCard(table.TakeTopCard());
            }
        }
    }

}
