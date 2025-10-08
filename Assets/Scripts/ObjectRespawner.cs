using UnityEngine;

public class ObjectRespawner : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = new Vector3(22.78f, 27f, 5.54f);
        collision.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        GetComponent<AudioSource>().Play();
    }
}
