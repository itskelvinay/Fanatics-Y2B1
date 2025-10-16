using System.Collections;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    public CanvasGroup FadeCanvasGroup;

    public void FadeIn(float duration = 1f)
    {
        StartCoroutine(Fade(0, 1, duration));
    }

    public void FadeOut(float duration = 1f)
    {
        StartCoroutine(Fade(1, 0, duration));
    }

    private IEnumerator Fade(float from, float to, float duration)
    {
        float elapsed = 0f;
        while(elapsed < duration)
        {
            FadeCanvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        FadeCanvasGroup.alpha = to;
    }


}
