using UnityEngine;

public class shed : MonoBehaviour
{
    private bool PlayerInShed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInShed = true;
        }

    }

    private void Update()
    {
        if (PlayerInShed)
        {
            TaskManager.Instance.CompleteTask(3);
        }
    }
}
