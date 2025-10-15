using UnityEngine;

public class Pond : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponentInChildren<WaterCanister>()?.Refill();
    }
}
