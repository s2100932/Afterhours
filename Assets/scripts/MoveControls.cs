using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveControls : MonoBehaviour
{
    Rigidbody rb;
   public Collider ColliderHit;

    public float MoveSpeed=7;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speedLimit();
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


        if (moveDir.magnitude > 0.1)
        {
            rb.AddForce(moveDir.normalized * MoveSpeed * 10f, ForceMode.Acceleration);
        }
    }

    private void speedLimit()
    {
        Vector3 Flatvel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (Flatvel.magnitude > MoveSpeed)
        {
            Vector3 Limit = Flatvel.normalized * MoveSpeed;
            rb.linearVelocity = new Vector3(Limit.x, rb.linearVelocity.y, Limit.z);
        }


    }

    void OnTriggerEnter(Collider collision)
    {
       ColliderHit = collision.gameObject.GetComponent<Collider>() ;
    }
}
