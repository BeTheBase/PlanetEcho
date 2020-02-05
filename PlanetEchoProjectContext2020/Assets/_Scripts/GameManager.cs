using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bas
{
    public class GameManager : MonoBehaviour
    {
        public void GoToLevel(int index)
        {
            SceneManager.LoadSceneAsync(index);
        }
    }
}
