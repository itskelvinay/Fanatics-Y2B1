using UnityEngine;

public class LavenderPot_script : MonoBehaviour
{
    bool hasSeed = false;
    bool hasWater = false;
    bool potOccupied = false;

    [Tooltip("Lavender plant prefab to spawn")]
    [SerializeField] GameObject LavenderPrefab;

    [Tooltip("Place empty GameObjects here to set lavender positions")]
    [SerializeField] Transform[] lavenderSpots; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Seed"))
        {
            Destroy(collision.gameObject);
            hasSeed = true;
            TryToGrow();
            Debug.Log("Lavender seed planted!");
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            hasWater = true;
            TryToGrow();
            Debug.Log("Water added to lavender pot!");
        }
    }

    void TryToGrow()
    {
        if (hasSeed && hasWater && !potOccupied)
        {
            GrowLavenders();
        }
    }

    void GrowLavenders()
    {
        Debug.Log("Lavenders are growing!");

        // Loop through all lavender spot markers
        foreach (Transform spot in lavenderSpots)
        {
            // Create lavender at each spot’s position
            GameObject lavender = Instantiate(LavenderPrefab, spot.position, spot.rotation);

            // Parent the lavender to this pot so it moves with it
            lavender.transform.parent = this.transform;

            // Optional: zero out local rotation and scale to keep them uniform
            lavender.transform.localRotation = Quaternion.identity;
        }

        potOccupied = true;
        Debug.Log("All lavenders planted!");
    }
}
