using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ObjectRespawner : MonoBehaviour
{
    [SerializeField] private AudioClip secretClip;
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        collision.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        GetComponent<AudioSource>().Play();
        if (collision.gameObject.CompareTag("Trash"))
        {
            GameObject.Instantiate(collision.gameObject);
            int trashCount = GameObject.FindGameObjectsWithTag("Trash").Length;
            if(trashCount > 15)
            {
                
            }
        }
    }
}
