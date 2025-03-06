using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    void Update()
    {
        scoreText.text = "You Score:\n" + scoreKeeper.GetScore().ToString();
    }
}
