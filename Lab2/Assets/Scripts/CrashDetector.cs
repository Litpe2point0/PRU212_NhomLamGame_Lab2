using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] AudioClip crashSFX;
    LevelManager levelManager;
    SpecialEffect specialEffect;
    bool isCrash = false;
    private void Awake()
    {
        levelManager = FindFirstObjectByType<LevelManager>();
        specialEffect = GetComponent<SpecialEffect>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && !isCrash)
        {
            isCrash = true;
            FindFirstObjectByType<Player>().DisableControls();
            specialEffect.PlayEffect();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            levelManager.LoadStage1(delay);
        }
    }
}
