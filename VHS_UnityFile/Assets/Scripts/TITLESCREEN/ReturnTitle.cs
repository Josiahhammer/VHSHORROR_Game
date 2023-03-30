using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ReturnTitle : MonoBehaviour
{
    public float loadingTime = 2f;

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(LoadMainScene());
        }
    }

    IEnumerator LoadMainScene()
    {
        // Unload the loading scene
        SceneManager.UnloadSceneAsync("MainScene");

        // Load the main scene
        SceneManager.LoadScene("TitleScreen");
        yield return null;
    }

}
