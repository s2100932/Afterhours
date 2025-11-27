using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveControls : MonoBehaviour
{
    Rigidbody rb;
    public Collider ColliderHit;

    public float MoveSpeed = 15f;
    public float SprintMultiplier = 2f;   // <-- NEW: Sprint speed multiplier
    public KeyCode SprintKey = KeyCode.LeftShift;

    private Animator animator;
    public float rotationSpeed = 12f;
    private Vector3 moveInput;

    private float currentSpeed; // <-- NEW: actual speed used

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        currentSpeed = MoveSpeed;
    }

    void Update()
    {
        speedLimit();

        float vert = Input.GetAxisRaw("Vertical");
        float hor = Input.GetAxisRaw("Horizontal");

        moveInput = new Vector3(hor, 0, vert).normalized;

        // Animation
        animator.SetBool("isWalking", moveInput.magnitude > 0.1f);

        // ----------------------------
        // SPRINT LOGIC
        // ----------------------------
        if (Input.GetKey(SprintKey) && moveInput.magnitude > 0.1f)
        {
            currentSpeed = MoveSpeed * SprintMultiplier;      // Sprinting
        }
        else
        {
            currentSpeed = MoveSpeed;                         // Walking
        }

        // ----------------------------
        // ROTATION
        // ----------------------------
        if (moveInput.magnitude > 0.1f)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveInput, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (moveInput.magnitude > 0.1f)
        {
            rb.AddForce(moveInput * currentSpeed * 10f, ForceMode.Acceleration);
        }
    }

    private void speedLimit()
    {
        float maxSpeed = currentSpeed; // <-- Speed limit respects sprint

        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        if (flatVel.magnitude > maxSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        ColliderHit = collision.gameObject.GetComponent<Collider>();
    }
}
