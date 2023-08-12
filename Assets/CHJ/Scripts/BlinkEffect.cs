using UnityEngine;
using System.Collections;

public class BlinkEffect : MonoBehaviour
{
    private Renderer rend;
    private Color originalColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void StartBlinking(float duration, float speed)
    {
        StartCoroutine(Blink(duration, speed));
    }

    private IEnumerator Blink(float duration, float speed)
    {
        float startTime = Time.time;
        float endTime = startTime + duration;

        while (Time.time < endTime)
        {
            float alpha = Mathf.PingPong(Time.time * speed, 0.5f) + 0.5f;  // 0.5 (50%) 에서 1.0 (100%) 사이의 값
            rend.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }
        rend.material.color = originalColor;  // 원래 색상으로 복원
    }
}