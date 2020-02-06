using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bas
{
    public interface IDialogueManager
    {
        void GetDialogueLineBySeqeuenceID(int id, string name);
    }
}
