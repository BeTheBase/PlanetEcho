using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bas
{
    public class NpcTrigger : MonoBehaviour
    {
        public int DialogueSequenceID = 0;
        public string DialogueLineName = string.Empty;
        public float PlayerFreezeTime = 10f;
        public void TriggerDialogue()
        {
            DialogueManager.Instance.GetDialogueLineBySeqeuenceID(DialogueSequenceID, DialogueLineName);
        }
    }
}
