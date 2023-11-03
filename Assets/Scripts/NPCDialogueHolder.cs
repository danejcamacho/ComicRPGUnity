using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueHolder : MonoBehaviour
{
    public string[] linesOfDialogue;

    public string[] GetMyDialogue(){
        return linesOfDialogue;
    }


}
