using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Bas
{
    public class GameManager : MonoBehaviour
    {
        private bool loadScene = false;

        public void GoToLevel(string levelName)
        {

            if (loadScene) return;

            loadScene = true;

            StartCoroutine(LoadNewScene(levelName));
        }


        // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
        private IEnumerator LoadNewScene(string levelName)
        {
            // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
            AsyncOperation async = SceneManager.LoadSceneAsync(levelName);

            // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
            while (!async.isDone)
            {
                yield return null;
            }

            loadScene = false;
        }
    }
}
