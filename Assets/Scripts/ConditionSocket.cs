using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

// Add this to your interactable objects (seeds, soil, etc.)
public class SnapTag : MonoBehaviour
{
    [Tooltip("Tags that define what this object is")]
    public string[] objectTags = new string[] { "seed" };
}

// Replace the default XRSocketInteractor with this custom one
public class ConditionalXRSocket : XRSocketInteractor
{
    [Header("Socket Requirements")]
    [Tooltip("Tags required on objects to snap here")]
    public string[] requiredTags = new string[] { };

    [Tooltip("Additional socket requirements (e.g., other sockets that must have objects)")]
    public ConditionalXRSocket[] requiredSockets = new ConditionalXRSocket[] { };

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        if (!base.CanHover(interactable))
            return false;

        return CheckCompatibility(interactable);
    }

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        if (!base.CanSelect(interactable))
            return false;

        return CheckCompatibility(interactable);
    }

    private bool CheckCompatibility(IXRInteractable interactable)
    {
        // Check if required sockets have objects
        foreach (var socket in requiredSockets)
        {
            if (socket != null && !socket.hasSelection)
            {
                return false;
            }
        }

        // If no tags required, allow any object
        if (requiredTags.Length == 0)
            return true;

        // Check if object has required tags
        var snapTag = interactable.transform.GetComponent<SnapTag>();
        if (snapTag == null)
            return false;

        // Object must have at least one matching tag
        foreach (var reqTag in requiredTags)
        {
            foreach (var objTag in snapTag.objectTags)
            {
                if (reqTag == objTag)
                    return true;
            }
        }

        return false;
    }
}