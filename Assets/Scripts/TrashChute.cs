using UnityEngine;

public class TrashChute : MonoBehaviour
{
    private bool PlayerNearChute = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNearChute = true;
        }

    }

    private void Update()
    {
        if (PlayerNearChute)
        {
            TaskManager.Instance.CompleteTask(4);
        }
    }
}
