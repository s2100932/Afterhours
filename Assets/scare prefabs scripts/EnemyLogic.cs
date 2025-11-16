using JetBrains.Annotations;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
   
    public Transform playerPos;
    public MeshRenderer enemyMesh;
    public Rigidbody rb;
    private bool chasePlayer = false;

    void Start()
    {
        if (enemyMesh != null)
            enemyMesh.enabled = false;
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
        if (chasePlayer && playerPos != null)
        {
            // Rotate the sphere, NOT the trigger
            rb.transform.LookAt(playerPos);

            float distance = Vector3.Distance(playerPos.position, rb.transform.position);

            if (distance > 0f)
            {
                rb.AddForce(rb.transform.forward * 8f * Time.deltaTime, ForceMode.VelocityChange);
            }
            else 
            {
                chasePlayer = false;
                rb.linearVelocity = Vector3.zero;
            }
        }
    }
}
