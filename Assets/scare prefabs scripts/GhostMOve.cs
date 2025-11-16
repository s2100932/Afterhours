using UnityEngine;

public class ghostMove : MonoBehaviour
{
    private bool chasePlayer = false;
    public Transform endpoint;
    public MeshRenderer enemyMesh;
    public Rigidbody rb;
    public GameObject ghost;

    void Start()
    {
        if (enemyMesh != null)
            enemyMesh.enabled = false;

        rb.linearVelocity= Vector3.zero;   // correct property
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (enemyMesh != null)
                enemyMesh.enabled = true;

            chasePlayer = true;
        }
    }

    void Update()
    {
        if (chasePlayer && endpoint != null)
        {
            rb.transform.LookAt(endpoint);

            float distance = Vector3.Distance(endpoint.position, rb.transform.position);

            // Move strongly toward the endpoint
            if (distance > 0.0f)
            {
                rb.AddForce(rb.transform.forward * 50f, ForceMode.Acceleration);
            }
            else
            {
                // reached the spot
                ghost.SetActive(false);
                rb.linearVelocity = Vector3.zero;
            }
        }
    }
}
