using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogOption
{
    public string optionText;
    public DialogData nextDialog;
}

[CreateAssetMenu(menuName = "Dialog/Dialog Data")]
public class DialogData : ScriptableObject
{
    [TextArea(3, 6)]
    public string npcText;

    public List<DialogOption> options;
}
