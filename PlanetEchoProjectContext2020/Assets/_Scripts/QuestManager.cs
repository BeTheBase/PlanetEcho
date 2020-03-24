using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

namespace Ruben
{
    public class QuestManager : MonoBehaviour
    {
        public void StartQuest(string questName)
        {
            QuestLog.StartQuest(questName);
        }

        public void CompleteQuest(string questName)
        {
            if (QuestLog.CurrentQuestState(questName) == "success")
            {
                QuestLog.SetQuestState(questName, QuestState.Success);
            }
        }
    }
}
