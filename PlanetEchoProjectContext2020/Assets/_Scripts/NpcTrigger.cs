﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bas
{
    public class NpcTrigger : MonoBehaviour
    {
        public int DialogueSequenceID = 0;
        public List<string> DialogueLineNames;
        public float PlayerFreezeTime = 10f;
        public float DialogueLineWaitTime = 5f;

        public bool test = false;

        private int dialogueIndex = 0;

        private void Start()
        {
            if (test)
                TriggerDialogue();
        }
        public void TriggerDialogue()
        {
            //DialogueManager.Instance.GetDialogueLineBySeqeuenceID(DialogueSequenceID, DialogueLineNames[0]);
            StartCoroutine(PlaySequences(DialogueLineNames[dialogueIndex]));
        }

        private IEnumerator PlaySequences(string name)
        {
            dialogueIndex += 1;
            DialogueManager.Instance.GetDialogueLineBySeqeuenceID(DialogueSequenceID, name);
            yield return new WaitForSeconds(DialogueLineWaitTime);
            if(dialogueIndex > DialogueLineNames.Count)
            {
                //DialogueLineWaitTime = 0;
            }
            else
            {
                StartCoroutine(PlaySequences(DialogueLineNames[dialogueIndex]));
            }
        }
    }
}
