using UnityEngine;

public class ObjectRespawner : MonoBehaviour
{
    [SerializeField] private AudioClip secretClip;

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = new Vector3(22.78f, 27f, 5.54f);
        collision.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        GetComponent<AudioSource>().Play();
        if (collision.gameObject.CompareTag("Trash"))
        {
            GameObject.Instantiate(collision.gameObject);
            int trashCount = GameObject.FindGameObjectsWithTag("Trash").Length;
            if(trashCount > 10)
            {
                GetComponent<AudioSource>().PlayOneShot(secretClip);
            }
        }
    }
}
