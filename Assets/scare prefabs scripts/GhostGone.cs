using UnityEngine;

public class GhostGone : MonoBehaviour
{
    public GameObject ghost;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ghost.SetActive(false);
        }
    }
}
