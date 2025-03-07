using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] AudioClip crashSFX;
    SpecialEffect specialEffect;
    bool isCrash = false;
    UIManager manager;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        manager = FindFirstObjectByType<UIManager>();
        specialEffect = GetComponent<SpecialEffect>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && !isCrash)
        {
            isCrash = true;
            FindFirstObjectByType<Player>().DisableControls();
            FindFirstObjectByType<Player>().Stop();
            specialEffect.PlayEffect();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            scoreKeeper.SetHighScore();
            manager.ShowGameOver();
        }
    }
}
