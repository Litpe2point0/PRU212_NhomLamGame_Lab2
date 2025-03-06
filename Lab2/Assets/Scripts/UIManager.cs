using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Menu")]
    public CanvasGroup menuPanel;

    [Header("GameOver")]
    public CanvasGroup gameOverPanel;

    [Header("Win")]
    public CanvasGroup winPanel;

    //[Header("Objective")]
    //public CanvasGroup objectivePanel;

    private bool isMenuVisible = false;
    private bool isGameOverVisible = false;
    private bool isWinVisible = false;
    public float fadeDuration = 1f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        isMenuVisible = !isMenuVisible;
        StopAllCoroutines();
        StartCoroutine(FadeMenu(isMenuVisible, menuPanel));
    }

    public void ShowGameOver()
    {
        isGameOverVisible = true;
        StopAllCoroutines();
        StartCoroutine(FadeMenu(isGameOverVisible, gameOverPanel));
    }

    public void ShowWin()
    {
        isWinVisible = true;
        StopAllCoroutines();
        StartCoroutine(FadeMenu(isWinVisible, winPanel));
    }

    IEnumerator FadeMenu(bool show, CanvasGroup menu)
    {
        float startAlpha = menu.alpha;
        float endAlpha = show ? 1 : 0;
        float elapsedTime = 0f;

        menu.interactable = show;
        menu.blocksRaycasts = show;

        while (elapsedTime < fadeDuration)
        {
            menu.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        menu.alpha = endAlpha;
    }

    //public void ShowObjective(float displayTime)
    //{
    //    StopAllCoroutines();
    //    StartCoroutine(FadeObjective(displayTime));
    //}

    //IEnumerator FadeObjective(float displayTime)
    //{
    //    yield return FadeMenu(true); // Show
    //    yield return new WaitForSeconds(displayTime);
    //    yield return FadeMenu(false); // Hide
    //}
}
