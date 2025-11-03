using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class EndSequenceController : MonoBehaviour
{
    [Header("UI / Fade")]
    public CanvasGroup fadeCanvas; // a black image with CanvasGroup alpha=0
    public float fadeDuration = 1f;

    [Header("Video")]
    public VideoPlayer videoPlayer; // assign your end-scene video here
    public AudioSource videoAudio;  // optional: assign if you want sound
    public Renderer videoRenderer;  // assign the Quad or Plane's Renderer (NEW)

    [Header("Countdown")]
    public float invisibleCountdownSeconds = 20f;

    private bool started = false;
    [SerializedField] public GameObject EndSequence;
    [SerializedField] public GameObject VideoPlane;
    public void StartEndSequence()
    {
        started = true;
        EndSequence.SetActive(true);
    }
    void Update()
    {
        if (started == true)
        {
            PlayAfterCountdown();
        }
    }
    private IEnumerator PlayAfterCountdown()
    {
        if (invisibleCountdownSeconds >= 0)
        {
            invisibleCountdownSeconds -= Time.deltaTime;
            Debug.Log(invisibleCountdownSeconds);
        }
        else
        { // Fade to black
            VideoPlane.SetActive(true);
            yield return StartCoroutine(FadeCanvas(0, 1, fadeDuration));

            // Play video
            if (videoRenderer) videoRenderer.enabled = true; // show the video screen
            videoPlayer.Play();
            if (videoAudio) videoAudio.Play();

            // Optional: fade back in after short delay
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(FadeCanvas(1, 0, fadeDuration));

            started = false;
        }


    }

    private IEnumerator FadeCanvas(float from, float to, float duration)
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

internal class SerializedFieldAttribute : Attribute
{
}