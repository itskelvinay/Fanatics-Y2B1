using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 10f)
        {
            transform.position = new Vector3(7f, 26f, 7.5f);
        }
    }
}
