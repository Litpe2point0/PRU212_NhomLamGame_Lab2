using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float slowDownFactor = 0.5f; // 50% speed reduction
    [SerializeField] private float slowDownDuration = 2f; // 2 seconds slow down
    [SerializeField] AudioClip crashSFX;
    bool oneTime = false;
    SpecialEffect specialEffect;
    SurfaceEffector2D surfaceEffector2D;
    ScoreKeeper scoreKeeper;
    UIDisplay uiDisplay;
    private void Awake()
    {
        specialEffect = GetComponent<SpecialEffect>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        uiDisplay = FindFirstObjectByType<UIDisplay>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && !oneTime)
        {
            oneTime = true;
            StartCoroutine(SlowDown(surfaceEffector2D, other));
            specialEffect.PlayEffect();
            other.GetComponent<AudioSource>().PlayOneShot(crashSFX);
            uiDisplay.ShowPoint(-100);
            scoreKeeper.ModifyScore(-100);
        }
    }

    private IEnumerator SlowDown(SurfaceEffector2D effector, Collider2D other)
    {
        other.gameObject.GetComponent<Player>().DisableBoost();
        float originalSpeed = effector.speed;
        effector.speed *= slowDownFactor; // Reduce speed

        yield return new WaitForSeconds(slowDownDuration);

        effector.speed = originalSpeed; // Restore speed
        other.gameObject.GetComponent<Player>().EnableBoost();
        Destroy(gameObject);
    }
}
