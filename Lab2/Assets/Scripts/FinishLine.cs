using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    [SerializeField] float delay;
    LevelManager levelManager;
    SpecialEffect specialEffect;
    private void Awake()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
        specialEffect = GetComponent<SpecialEffect>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            specialEffect.PlayEffect();
            GetComponent<AudioSource>().Play();
            levelManager.LoadStage1(delay);
        }
    }
}
