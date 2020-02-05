using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bas
{
    public class DialogueManager : MonoBehaviour
    {
        public List<DialogueWrapper> DialogueWrappers;

        private string jsonString = "";
        public void SaveDialogues()
        {
            JsonConverter<DialogueWrapper>.SerializeToJson(DialogueWrappers, jsonString, "DialogueWrapperJson");
        }
    }
}
