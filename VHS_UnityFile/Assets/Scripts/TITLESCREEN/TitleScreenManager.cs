using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleScreenManager : MonoBehaviour
{
    public string loadingSceneName = "LOADING";
    public string mainSceneName = "MainScene";
    public string titleSceneName = "TitleScreen";
    public float loadingTime = 2f;

    private bool isLoading = false;



    void Update()
    {
        if (!isLoading && Input.GetKeyDown(KeyCode.Space))
        {
            isLoading = true;
            SceneManager.UnloadSceneAsync("TitleScreen");
            StartCoroutine(LoadMainScene());

        }
    }

    IEnumerator LoadMainScene()
    {
        // Load the loading scene
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync("LOADING", LoadSceneMode.Additive);

        // Wait for the loading scene to finish loading
        while (!loadingOperation.isDone)
        {
            yield return null;
        }

        // Wait for 3 seconds
        yield return new WaitForSeconds(2f);

        // Unload the loading scene
        SceneManager.UnloadSceneAsync("LOADING");

        // Load the main scene
        SceneManager.LoadScene("MainScene");

        isLoading = false;

    }

}
