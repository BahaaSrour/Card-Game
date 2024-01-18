using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Game Mode")]
public class ModeSO :ScriptableObject
{
    public Board mode;
    public string modeName;
    [TextArea]
    public string modeDescription;
    public bool isAvailable;
}
