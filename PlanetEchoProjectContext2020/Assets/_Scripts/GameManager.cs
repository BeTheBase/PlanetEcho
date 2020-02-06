using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Bas
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        public GameObject Bike;

        public float LoadingTime = 3f;

        private bool loadScene = false;

        [SerializeField]
        private Text loadingText;

        private void Start()
        {
            DialogueManager.Instance.GetDialogueLineBySeqeuenceID(0, "Test");
        }

        public void GoToLevel(int index)
        {
            Bike.SetActive(true);
            // ...set the loadScene boolean to true to prevent loading a new scene more than once...
            loadScene = true;

            // ...change the instruction text to read "Loading..."
            loadingText.text = "Loading...";

            EventManager<int>.BroadCast(EVENT.loadGame, index);
            // ...and start a coroutine that will load the desired scene.
            StartCoroutine(LoadNewScene(index));

        }

        private void Update()
        {
            // If the new scene has started loading...
            if (loadScene == true)
            {

                // ...then pulse the transparency of the loading text to let the player know that the computer is still working.
                loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

            }
        }

        // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
        private IEnumerator LoadNewScene(int index)
        {

            // This line waits for 3 seconds before executing the next line in the coroutine.
            // This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
            yield return new WaitForSeconds(LoadingTime);

            // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
            AsyncOperation async = SceneManager.LoadSceneAsync(index);

            // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
            while (!async.isDone)
            {
                yield return null;
            }

        }
    }
}
