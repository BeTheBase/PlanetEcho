using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTextScroll : MonoBehaviour
{
    public GameObject IntroText;
    public Transform Destination;
    public float ScrollSpeed = 4f;
    public float LoadTime = 10f;

    public void StartGame(int index)
    {
        IntroText.SetActive(true);
        IntroText.transform.LerpTransform(this, Destination.position, ScrollSpeed);
        StartCoroutine(LoadScene(index));
    }

    private IEnumerator LoadScene(int index)
    {
        yield return new WaitForSeconds(LoadTime);
        SceneManager.LoadSceneAsync(index);
    }

}
