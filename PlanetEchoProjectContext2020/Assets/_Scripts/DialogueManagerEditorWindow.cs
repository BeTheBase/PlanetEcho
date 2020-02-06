using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Bas
{
    [CustomEditor(typeof(DialogueManager))]
    public class DialogueManagerEditorWindow : Editor
    {
        private DialogueManager dialogueManager;
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            dialogueManager = (DialogueManager)target;

            if (GUILayout.Button("Save Dialogues"))
            {
                dialogueManager.SaveDialogues();
            }

            if(GUILayout.Button("Load Dialogues"))
            {
                dialogueManager.LoadDialogues();
            }
        }
    }
}
