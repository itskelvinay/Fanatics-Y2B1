using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class FlowerBed : MonoBehaviour
{
    // Reference to the XR Socket Interactor (add this in Inspector)
    [Tooltip("The XR Socket Interactor component on this flower bed")]
    [SerializeField] private XRSocketInteractor socketInteractor;

    // The plant that is currently growing in this bed
    private KelvinPlant currentPlant;

    private void Start()
    {
        // Subscribe to socket events
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.AddListener(OnObjectPlaced);

            // IMPORTANT: Make socket only accept seeds
            socketInteractor.socketActive = true;
        }
    }

    /// <summary>
    /// This runs when something is placed in the socket
    /// </summary>
    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        // Check if the object placed is a seed
        PlantableSeed seed = args.interactableObject.transform.GetComponent<PlantableSeed>();

        if (seed != null)
        {
            Debug.Log("A seed was placed in the flower bed!");
            // Tell the seed it has been planted
            seed.OnPlanted(this);
        }
    }

    /// <summary>
    /// This checks if an object CAN be placed in the socket (only seeds allowed!)
    /// </summary>
    public bool CanSocketAccept(IXRSelectInteractable interactable)
    {
        // Only accept objects that have the PlantableSeed component
        PlantableSeed seed = interactable.transform.GetComponent<PlantableSeed>();
        return seed != null;
    }

    /// <summary>
    /// Set the plant that's growing in this bed
    /// </summary>
    public void SetPlantedPlant(KelvinPlant plant)
    {
        currentPlant = plant;
        Debug.Log("Flower bed now has a plant growing!");
    }

    /// <summary>
    /// Get the plant growing in this bed (used by water canister)
    /// </summary>
    public KelvinPlant GetPlant()
    {
        return currentPlant;
    }

    /// <summary>
    /// Check if there's a plant that can be watered
    /// </summary>
    public bool HasPlantToWater()
    {
        return currentPlant != null;
    }

    private void OnDestroy()
    {
        // Unsubscribe from events when destroyed
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.RemoveListener(OnObjectPlaced);
        }
    }
}