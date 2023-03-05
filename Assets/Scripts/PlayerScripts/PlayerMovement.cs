using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float velocity = 10f;
    [SerializeField] float acceleration = 10f;
    [SerializeField] float drag = 5f;

    Rigidbody2D rb;
    float horizontalInput, verticalInput;
    public Vector2 movementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        SpeedControl();
    }

    void FixedUpdate()
    {
        movementDirection = transform.right * horizontalInput + transform.up * verticalInput;

        if (movementDirection != Vector2.zero) rb.drag = 0;
        else rb.drag = drag;

        rb.AddForce(acceleration * velocity * movementDirection.normalized / Time.timeScale, ForceMode2D.Force);
    }

    void SpeedControl()
    {
        Vector2 flatVel = new(rb.velocity.x, rb.velocity.y);
        if (flatVel.magnitude > velocity)
        {
            Vector2 limitedVel = flatVel.normalized * velocity;
            rb.velocity = new Vector2(limitedVel.x, limitedVel.y);
        }
    }
}
