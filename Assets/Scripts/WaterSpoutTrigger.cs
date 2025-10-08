using UnityEngine;

public class WaterSpoutTrigger : MonoBehaviour
{
    // Reference to the parent water canister
    private WaterCanister waterCanister;

    private void Start()
    {
        // Get the water canister from the parent
        waterCanister = GetComponentInParent<WaterCanister>();
    }

    /// <summary>
    /// Detect when the water spout touches something
    /// </summary>
    private void OnTriggerStay(Collider other)
    {
        // Only water if the canister is being held
        if (waterCanister == null || !waterCanister.IsBeingHeld())
        {
            return;
        }

        // Check if we're touching a flower bed
        FlowerBed flowerBed = other.GetComponent<FlowerBed>();

        if (flowerBed != null && flowerBed.HasPlantToWater())
        {
            // Water the plant!
            KelvinPlant plant = flowerBed.GetPlant();
            plant.StartWatering();
            Debug.Log("Watering the plant!");
        }
    }
}