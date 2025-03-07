using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIDisplay : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] GameObject scorePoint;
    [SerializeField] Transform scorePointParent;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }
 
    void Update()
    {
        highScore.text = "High Score: " + scoreKeeper.GetHighScore().ToString();
        scoreText.text = scoreKeeper.GetScore().ToString("00000000");
    }
    public void ShowPoint(int score)
    {
        GameObject point = Instantiate(scorePoint, scorePointParent.position, Quaternion.identity);
        point.transform.SetParent(scorePointParent, true);

        // Set the text if needed (if your score point has a TMP component)
        TextMeshProUGUI pointText = point.GetComponentInChildren<TextMeshProUGUI>();
        if (pointText != null)
        {
            pointText.text = "+" + score.ToString();
        }

        // Start the fade-out and movement effect
        StartCoroutine(FadeAndMove(point));
    }

    IEnumerator FadeAndMove(GameObject point)
    {
        float duration = 1f;
        float elapsed = 0f;
        Vector3 startPosition = point.transform.position;
        Vector3 targetPosition = startPosition + Vector3.up * 50f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            point.transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            yield return null;
        }

        Destroy(point);
    }
}
