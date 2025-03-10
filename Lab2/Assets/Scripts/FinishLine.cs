using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    [SerializeField] float delay;
    LevelManager levelManager;
    SpecialEffect specialEffect;
    UIManager manager;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        manager = FindFirstObjectByType<UIManager>();
        levelManager = FindFirstObjectByType<LevelManager>();
        specialEffect = GetComponent<SpecialEffect>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            specialEffect.PlayEffect();
            GetComponent<AudioSource>().Play();
            FindFirstObjectByType<Player>().DisableControls();
            FindFirstObjectByType<Player>().Stop();
            manager.ShowWin();
        }
    }
}
