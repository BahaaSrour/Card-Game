using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGAmeCanvas : MonoBehaviour
{
    public ScriptableEvent<Player[], int> OnEndGameSO;
    public TMPro.TMP_Text[] playerScores;
    public TMPro.TMP_Text winner;
    private void Awake()
    {
        OnEndGameSO.addListener(EndGame);
    }

    private void EndGame(Player[] players, int winerindex)
    {
        GetComponent<Canvas>().enabled = true;
        for (int i = 0; i < 4; i++) 
        {
            playerScores[i].text = players[i].wonRounds.ToString();
        }
        winner.text = $"Player Number {winerindex + 1} scored {players[winerindex].wonRounds}";
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
