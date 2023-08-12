using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

public class FadeEffect : MonoBehaviour
{
    private Image fadeImage;
    private bool isFading = false;

    private void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    public IEnumerator FadeIn(float duration)
    {
        if (isFading) yield break; // 이미 페이드 중이라면 코루틴 종료
        isFading = true;

        float startAlpha = fadeImage.color.a;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, 0, time / duration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            yield return null;
        }

        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
        isFading = false;
    }

    public IEnumerator FadeOut(float duration)
    {
        if (isFading) yield break; // 이미 페이드 중이라면 코루틴 종료
        isFading = true;

        float startAlpha = fadeImage.color.a;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, 1, time / duration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            yield return null;
        }

        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
        isFading = false;
    }
}