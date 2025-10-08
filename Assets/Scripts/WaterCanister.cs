using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WaterCanister : MonoBehaviour
{
    [Tooltip("Optional: Particle system for water effect")]
    [SerializeField] private ParticleSystem waterParticles;

    // Check if player is holding the canister
    private XRGrabInteractable grabInteractable;
    private bool isBeingHeld = false;

    // Reference to rigidbody
    private Rigidbody rb;

    private void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody>();

        // Make it stay in place until grabbed
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // Get the grab interactable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            // Subscribe to grab events
            grabInteractable.selectEntered.AddListener(OnGrabbed);
            grabInteractable.selectExited.AddListener(OnReleased);
        }

        // Turn off water particles at start
        if (waterParticles != null)
        {
            waterParticles.Stop();
        }
    }

    /// <summary>
    /// Called when player grabs the canister
    /// </summary>
    private void OnGrabbed(SelectEnterEventArgs args)
    {
        isBeingHeld = true;

        // Enable physics when grabbed
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        Debug.Log("Water canister grabbed!");

        // Turn on water particles when held
        if (waterParticles != null)
        {
            waterParticles.Play();
        }
    }

    /// <summary>
    /// Called when player releases the canister
    /// </summary>
    private void OnReleased(SelectExitEventArgs args)
    {
        isBeingHeld = false;

        Debug.Log("Water canister released!");

        // Turn off water particles when released
        if (waterParticles != null)
        {
            waterParticles.Stop();
        }
    }

    /// <summary>
    /// Public method so the water spout can check if we're being held
    /// </summary>
    public bool IsBeingHeld()
    {
        return isBeingHeld;
    }

    private void OnDestroy()
    {
        // Unsubscribe from events when destroyed
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
            grabInteractable.selectExited.RemoveListener(OnReleased);
        }
    }
}