using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ModeManager : MonoBehaviour
{
    public Player[] players;
    public List<ModeSO> modes;
    public ModeSO currentMode;
    public GameObject ModeButton;
    public Transform ModeButtonContainer;
    public Canvas SelectModeCanvas;
    public Canvas playerCardsCanvas;
    public Canvas TableCanvas;


    private void Start()
    {

        InstantiateModesButtons();
    }
    void InstantiateModesButtons()
    {
        for (int i = 0; i < modes.Count; i++) 
        {
            var x = i;
            var tmp=Instantiate(ModeButton, ModeButtonContainer);
            tmp.GetComponent<ModeButton>().SetCurrentMode(modes[i]);
            tmp.GetComponent<Button>().onClick.AddListener(()=>SetCurrentMode(tmp.GetComponent<ModeButton>().currentMode)) ; 
        }
    }

    void SetCurrentMode(ModeSO val)
    {
        currentMode = val;
        StartMode();
    }

    void StartMode()
    {
        Board mode = Instantiate(currentMode.mode);
        mode.players = players;
        SelectModeCanvas.enabled = false;
        playerCardsCanvas.enabled = true; ;
        TableCanvas.enabled=true;
        mode.StartNewGame();
    }
}
