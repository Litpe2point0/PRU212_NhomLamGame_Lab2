using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public void LoadStage1(float delay)
    {
        StartCoroutine(WaitAndLoad("Stage1", delay));
    }
    public void LoadGameOver(float delay)
    {
        StartCoroutine(WaitAndLoad("GameOver", delay));
    }

    public void LoadWin()
    {
        SceneManager.LoadScene("Win");
    }

    public void QuitGame()
    {
        Application.Quit(); //Work for standalone builds
    }
    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
