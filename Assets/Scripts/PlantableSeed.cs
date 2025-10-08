using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlantableSeed : MonoBehaviour
{
    [Tooltip("The plant prefab that will grow from this seed")]
    [SerializeField] private GameObject plantPrefab;

    // Reference to the plant that gets created
    private KelvinPlant spawnedPlant;

    // Check if this seed has been planted
    private bool isPlanted = false;

    /// <summary>
    /// This gets called when the seed is placed in a socket (flower bed)
    /// </summary>
    public void OnPlanted(FlowerBed flowerBed)
    {
        if (isPlanted) return; // Already planted

        isPlanted = true;
        Debug.Log("Seed planted in flower bed!");

        // Spawn the plant at this seed's position
        GameObject plantObj = Instantiate(plantPrefab, transform.position, transform.rotation);
        spawnedPlant = plantObj.GetComponent<KelvinPlant>();

        // Tell the flower bed about the plant
        flowerBed.SetPlantedPlant(spawnedPlant);

        // Hide the seed (or you can destroy it)
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Check if this seed is planted
    /// </summary>
    public bool IsPlanted()
    {
        return isPlanted;
    }
}