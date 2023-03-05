using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float jumpForce = 400;
    bool jump = false;
    public float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    /*void Jump()
    {
        rb.velocity = new Vector2(50, jumpForce * Time.deltaTime);
    }*/
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }*/
        rb.velocity = new Vector2(50, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, 50f), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(new Vector2(0, -50f), ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        /*if (jump == true)
        {
            Jump();
            jump = false;
        }*/
    }
}
