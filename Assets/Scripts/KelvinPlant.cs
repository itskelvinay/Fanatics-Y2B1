using UnityEngine;

public class KelvinPlant : MonoBehaviour
{
    // The amount the plant has grown (edit this)
    [Tooltip("The amount the plant has grown (edit this)")]
    [SerializeField] public float growth;

    // List of objects to go through (in order)
    [Tooltip("List of objects to go through (in order)")]
    [SerializeField] GameObject[] models;

    // NEW: Check if the plant has been watered
    [Tooltip("Has this plant been watered yet?")]
    [SerializeField] private bool hasBeenWatered = false;

    // We need to keep track in case we need to switch back
    int lastModel;

    /// <summary>
    /// Runs on start
    /// </summary>
    private void Start()
    {
        // Loop through all the models
        for (int i = 0; i < models.Length; i++)
        {
            // Set them to be very tiny
            models[i].transform.localScale = new Vector3(0, 0, 0);
        }
    }

    /// <summary>
    /// Runs every frame
    /// </summary>
    private void Update()
    {
        // NEW: Only grow if the plant has been watered!
        if (!hasBeenWatered)
        {
            return; // Stop here if not watered yet
        }

        GrowABit();

        // Calculate the important stuff
        int model = Mathf.FloorToInt(growth);
        float modelGrowth = growth % 1; // How much the current model has grown
        float scale = (modelGrowth / 2) + 0.5f;

        // Check if there are no more models to go
        if (model >= models.Length)
        {
            // Do something with the grown plant
            FullyGrown();

            // Stop doing stuff early
            return;
        }

        // Turn the correct model on
        models[model].transform.localScale = new Vector3(scale, scale, scale);

        // Turn off old model if needed
        if (lastModel != model)
        {
            // Set the scale of the old model to 0.
            models[lastModel].transform.localScale = new Vector3(0, 0, 0);

            // Make this model the new 'lastModel'
            lastModel = model;
        }
    }

    /// <summary>
    /// NEW: Call this function to start watering the plant!
    /// </summary>
    public void StartWatering()
    {
        // Only water if not already watered
        if (!hasBeenWatered)
        {
            hasBeenWatered = true;
            Debug.Log("Plant has been watered! It will now start growing.");
        }
    }

    /// <summary>
    /// Testing function that will make the plant grow a little bit, replace with own implementation
    /// </summary>
    void GrowABit()
    {
        // Grow a bit over time (You want to edit this)
        growth += Time.deltaTime / 10;
    }

    /// <summary>
    /// Gets run when the plant has fully grown (every frame)
    /// </summary>
    void FullyGrown()
    {
        // This code gets run every frame if the plant has no mo models to go trough
        Debug.Log("Yay, I have grown!");
    }
}
