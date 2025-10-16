using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CutSceneManager : MonoBehaviour
{
    [Header("Cutscene References")]
    [SerializeField] private XRBaseInteractor doorInteractor; // optional if you want to disable door use
    [SerializeField] private Transform exitTarget;
    [SerializeField] private Transform xrOrigin;
    [SerializeField] private float moveDuration = 2f;


    [Header("Screen Fade")]
    [SerializeField] private ScreenFader screenFader;

    private void Start()
    {
        // Find the screen fader automatically if not assigned
        if (screenFader == null)
            screenFader = FindObjectOfType<ScreenFader>();
    }

    public void TriggerCutscene()
    {
        StartCoroutine(PlayCutscene());
    }

    private IEnumerator PlayCutscene()
    {
        if (xrOrigin == null || exitTarget == null)
        {
            Debug.LogError("XR Origin or Exit Target not assigned in CutSceneManager!");
            yield break;
        }

        // Fade to black
        if (screenFader != null)
        {
            screenFader.FadeIn(1f);
            yield return new WaitForSeconds(1.2f);
        }

        // Move player from current position to the exit target
        Vector3 startPos = xrOrigin.position;
        Vector3 endPos = exitTarget.position;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            xrOrigin.position = Vector3.Lerp(startPos, endPos, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        xrOrigin.position = endPos;

        // Optional: rotate player to face a new direction
        xrOrigin.Rotate(0, 0, 0);

        // Fade back out
        if (screenFader != null)
        {
            screenFader.FadeOut(1f);
            yield return new WaitForSeconds(1f);
        }

        Debug.Log("Cutscene complete!");
    }
}
