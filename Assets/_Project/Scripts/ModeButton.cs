using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ModeButton : MonoBehaviour
{
    public TMP_Text modeName;
    public TMP_Text modeDescription;
    public ModeSO   currentMode;
    public Button button;

    public void SetCurrentMode( ModeSO _mode)
    {
        modeName.text= _mode.modeName;
        modeDescription.text= _mode.modeDescription;
        currentMode=_mode;
        button.interactable= _mode.isAvailable;
    }
}
