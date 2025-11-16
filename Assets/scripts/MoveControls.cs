using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveControls : MonoBehaviour
{
    Rigidbody rb;
    public Collider ColliderHit;

    public float MoveSpeed = 7f;
    private Animator animator; // <-- Add Animator reference

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // <-- Initialize Animator
    }

    void Update()
    {
        speedLimit();

        // Set walking animation based on input
        float vert = Input.GetAxisRaw("Vertical");
        float hor = Input.GetAxisRaw("Horizontal");
        animator.SetBool("isWalking", vert != 0 || hor != 0);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
    Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
{
    Debug.Log("Key pressed!");
}


    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float VertMove = Input.GetAxisRaw("Vertical") * MoveSpeed;
        float horMove = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        Vector3 moveDir = transform.forward * VertMove + transform.right * horMove;

        if (moveDir.magnitude > 0.1f)
        {
            rb.AddForce(moveDir.normalized * MoveSpeed * 10f, ForceMode.Acceleration);
        }
    }

    private void speedLimit()
    {
        // Fix: use rb.velocity instead of rb.linearVelocity
        Vector3 Flatvel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (Flatvel.magnitude > MoveSpeed)
        {
            Vector3 Limit = Flatvel.normalized * MoveSpeed;
            rb.velocity = new Vector3(Limit.x, rb.velocity.y, Limit.z);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        ColliderHit = collision.gameObject.GetComponent<Collider>();
    }
}
