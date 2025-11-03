using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class EndSequenceController : MonoBehaviour
{
    [Header("UI / Fade")]
    public CanvasGroup fadeCanvas; // a black image on screen with CanvasGroup alpha=0
    public float fadeDuration = 1f;

    [Header("Video")]
    public VideoPlayer videoPlayer; // assign your end-scene video here
    public AudioSource videoAudio;  // optional: assign if you want sound

    [Header("Countdown")]
    public float invisibleCountdownSeconds = 30f;

    private bool started = false;

    public void StartEndSequence()
    {
        if (started) return;
        started = true;
        StartCoroutine(PlayAfterCountdown());
    }

    private IEnumerator PlayAfterCountdown()
    {
        // Wait 30 seconds (invisible to player)
        yield return new WaitForSeconds(invisibleCountdownSeconds);

        // Fade to black
        yield return StartCoroutine(Fade(0, 1, fadeDuration));

        // Play video
        videoPlayer.Play();
        if (videoAudio) videoAudio.Play();
    }

    private IEnumerator Fade(float from, float to, float duration)
    {
        if (!fadeCanvas) yield break;
        float t = 0f;
        fadeCanvas.alpha = from;
        while (t < duration)
        {
            t += Time.deltaTime;
            fadeCanvas.alpha = Mathf.Lerp(from, to, t / duration);
            yield return null;
        }
        fadeCanvas.alpha = to;
    }
}
