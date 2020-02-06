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
            string dialogueLine = dialogueWrapper.Dialogues.Find(d => d.name.Equals(name)).DialogueText;
            StartCoroutine(AnimateText(0.5f, dialogueLine));
        }

        IEnumerator AnimateText(float animationTime = .5f, string str = "")
        {
                float elapsed = 0;
                string targetString = str;
                string startingString = "";
                while (elapsed < animationTime)
                {
                    elapsed += Time.deltaTime;
                    float t = elapsed / animationTime;
                str = targetString.Substring(0, Mathf.FloorToInt(targetString.Length * t)); // take the first n letters.
                DialogueLineTextField.text = str;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
