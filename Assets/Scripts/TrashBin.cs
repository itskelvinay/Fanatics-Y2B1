using UnityEngine;

public class TrashBin : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Trash")
        {
            Destroy(collision.gameObject);
        }
    }
}
