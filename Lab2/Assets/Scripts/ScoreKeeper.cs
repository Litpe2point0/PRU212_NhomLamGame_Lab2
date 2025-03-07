using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Rendering;

public class ScoreKeeper : MonoBehaviour
{
    int score;
    static ScoreKeeper instance;
    LevelManager levelManager;
    private const string HighScore = "HighScore";
    private void Awake()
    {
        ManageSingleton();
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene change event
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe to avoid memory leaks
    }

    void Start()
    {
        PlayerPrefs.GetFloat(HighScore, score);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        levelManager = FindFirstObjectByType<LevelManager>(); // Reassign LevelManager
        Debug.Log($"LevelManager reassigned in scene: {scene.name}");
    }
    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return score;
    }
    public void SetHighScore()
    {
        if (CheckHighScore(score))
        {
            PlayerPrefs.SetFloat(HighScore, score);
            PlayerPrefs.Save();
        };
    }
    public bool CheckHighScore(int score)
    {
        var temp = PlayerPrefs.GetFloat(HighScore);
        if (score > temp)
        {
            return true;
        }
        return false;
    }
    public int GetHighScore()
    {
        return (int)PlayerPrefs.GetFloat(HighScore, score);
    }
    public void ModifyScore(int value)
    {
        score += value;
        score = Mathf.Clamp(score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
