using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    List<GameObject> objectsToFlee = new List<GameObject>();
    public float moveSpeed;
    private void Flee()
    {
        Vector3 fleeVector = Vector3.zero;
        foreach (GameObject obj in objectsToFlee )
        {
            fleeVector += (obj.transform.position - transform.position);
        }
        fleeVector /= objectsToFlee.Count;
        MoveTowards(-fleeVector.normalized);
    }
    private void MoveTowards(Vector3 target)
    {
        if(rb.velocity.magnitude<= target.magnitude*moveSpeed)
            rb.AddForce(target*moveSpeed, ForceMode2D.Impulse);

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectsToFlee.Add(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        objectsToFlee.Remove(collision.gameObject);

    }
    private void FixedUpdate()
    {
        Flee();
    }
    
}
