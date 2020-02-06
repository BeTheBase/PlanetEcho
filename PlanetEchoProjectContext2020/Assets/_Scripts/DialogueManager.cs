using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Bas
{
    public class DialogueManager : GenericSingleton<DialogueManager, IDialogueManager>, IDialogueManager
    {
        public TextMeshProUGUI DialogueLineTextField;

        public List<DialogueWrapper> DialogueWrappers;

        private string jsonString = "";
        public void SaveDialogues()
        {         
            jsonString = JsonConverter<DialogueWrapper>.SerializeToJson(DialogueWrappers, jsonString, "/DialogueWrapperData.json");
            print(jsonString);
        }

        public void LoadDialogues()
        {           
            DialogueWrappers = JsonConverter<DialogueWrapper>.FromJson(jsonString, "/DialogueWrapperData.json");
        }

        public void GetDialogueLineBySeqeuenceID(int id, string name)
        {
            DialogueWrapper dialogueWrapper = DialogueWrappers.Find(dw => dw.DialogueSequenceID.Equals(id));
            Dialogue dialogue = dialogueWrapper.Dialogues.Find(d => d.name.Equals(name));
            if(dialogue.DialogueAudio != null)
            {
                //Play audio clip!
            }
            StartCoroutine(AnimateText(0.1f, dialogue.DialogueText));
        }

        IEnumerator AnimateText(float delay, string input)
        {
            string currentText = "";
            for(int index = 0; index < input.Length; index++)
            {
                currentText = input.Substring(0, index);
                DialogueLineTextField.text = currentText;
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
