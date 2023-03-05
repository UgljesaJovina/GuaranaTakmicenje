using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float jumpForce = 400;
    bool jump = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Jump()
    {
        rb.velocity = new Vector2(50, jumpForce * Time.deltaTime);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }
    void FixedUpdate()
    {
        if (jump == true)
        {
            Jump();
            jump = false;
        }
    }
}
