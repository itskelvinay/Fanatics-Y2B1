using UnityEngine;

public class KelvinPlant : MonoBehaviour
{
    public string type;

    // The amount the plant has grown (edit this)
    [Tooltip("The amount the plant has grown (edit this)")]
    [SerializeField] public float growth;

    // List of objects to go through (in order)
    [Tooltip("List of objects to go through (in order)")]
    [SerializeField] GameObject[] models;

    // Referance to the tree 
    TreeGrowth tree;


    // We need to keep track in case we need to switch back
    int lastModel;

    bool isFullyGrown = false;

    /// <summary>
    /// Runs on start
    /// </summary>
    private void Start()
    {
        // find tree
        tree = GameObject.FindAnyObjectByType<TreeGrowth>();

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
        if (isFullyGrown) return;

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
    /// Testing function that will make the plant grow a little bit, replace with own implementation
    /// </summary>
    void GrowABit()
    {
        // Grow a bit over time (You want to edit this)
        // #TODO make this grow slower prob.
        growth += Time.deltaTime / 10;
    }


    /// <summary>
    /// Gets run when the plant has fully grown (every frame)
    /// </summary>
    void FullyGrown()
    {
        TaskManager.Instance.RegisterGrownPlant(this);
        TaskManager.Instance.CompleteTask(1);
       
        // This code gets run every frame if the plant has no mo models to go trough
        Debug.Log("Yay, I have grown!");
        isFullyGrown = true;

    }

}