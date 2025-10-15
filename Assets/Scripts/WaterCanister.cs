using UnityEngine;
using UnityEngine.UI;

public class WaterCanister : MonoBehaviour
{
    [SerializeField] Transform WaterCanisterTilt;
    [SerializeField] Slider WaterLevelSlider;
    public float WaterLevel = 3.0f;
    // Update is called once per frame
    void Update()
    {
#pragma warning disable CS0618 // Disables warning for eneableEmission
        if (WaterCanisterTilt.forward.y < 0 && WaterLevel > 0) 
        {
            WaterCanisterCollider.enabled = true;
            WaterSplash.enableEmission = true;
            WaterLevel -= Time.deltaTime;
            WaterLevelSlider.value = WaterLevel;
            Debug.Log("The water canister is tilted forward.");
        }
        else
        {
            WaterSplash.enableEmission = false;
            WaterCanisterCollider.enabled = false;
        }
    }

    private ParticleSystem WaterSplash;
    private void Start()
    {
        WaterSplash = GetComponent<ParticleSystem>();
        WaterCanisterCollider = GetComponent<Collider>();
    }

    private Collider WaterCanisterCollider;
    public void Refill ()
    {
        if (WaterLevel < 3.0f)
            WaterLevel += Time.deltaTime;
        WaterLevelSlider.value = WaterLevel;
    }
}
