using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreKeeper : MonoBehaviour
{
    int score;
    static ScoreKeeper instance;
    LevelManager levelManager;

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
