using UnityEngine.SceneManagement;
using UnityEngine;

public class ReturnTitle : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.UnloadSceneAsync("MainScene");
            SceneManager.LoadScene("TitleScreen");
        }
    }
}
