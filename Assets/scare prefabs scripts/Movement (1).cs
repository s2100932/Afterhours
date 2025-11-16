
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    //put on player object not body
    public float moveSpeed;
    float horInput;
    float vertInput;
    Vector3 moveDir;
    public Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        inputDir();
        speedLimit();
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void inputDir()
    {
        horInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");
      
    }

    private void Movement()
    {
        moveDir = transform.forward *vertInput + transform.right * horInput;
        rb.AddForce(moveDir.normalized * moveSpeed , ForceMode.VelocityChange);
    }

    private void speedLimit()
    {
        Vector3 Flatvel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (Flatvel.magnitude > moveSpeed)
        {
            Vector3 Limit = Flatvel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(Limit.x, rb.linearVelocity.y, Limit.z);
        }
    }

}