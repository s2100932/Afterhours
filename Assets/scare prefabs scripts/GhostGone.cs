using UnityEngine;

public class GhostGone : MonoBehaviour
{
   public GameObject ghost;

    void OnTriggerEnter(Collider other)
    {
        ghost.SetActive(false);
    }
}
