using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }
    public void LoadStage1(float delay)
    {
        scoreKeeper.ResetScore();
        StartCoroutine(WaitAndLoad("Stage1", delay));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
