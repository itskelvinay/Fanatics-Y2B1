using UnityEngine;

public class Flowerpot_script : MonoBehaviour
{
    bool hasSeed = false;
    bool hasWater = false;
    bool potOccupied = false;

    [SerializeField] GameObject FlowerPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        // Do seed stuff
        if (collision.gameObject.CompareTag("Seed"))
        {
            Destroy(collision.gameObject); // Remove the seed from the scene
            hasSeed = true;
            TryToGrow();

            Debug.Log("The seed has been planted!");
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        // Do watering stuffs
        if (collision.gameObject.CompareTag("Water"))
        {
            hasWater = true;
            TryToGrow();

            Debug.Log("The water is in the pot!");
        }
    }

    void TryToGrow()
    {
        // Check if we should start growing
        if (hasSeed && hasWater && !potOccupied)
        {
            Grow();
        }
    }

    void Grow()
    {
        Debug.Log("We are growing!");

        // Spawn the flower object
        GameObject flower = Instantiate(FlowerPrefab, transform.position, Quaternion.identity);

        // Make it so the flower sticks to us
        flower.transform.parent = this.transform;
        Debug.Log("Yay, its growing xoxo Tygo!");

        potOccupied = true;
    }
}