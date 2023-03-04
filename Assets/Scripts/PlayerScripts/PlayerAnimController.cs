using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] Animator anim;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.Play("Walk");
        }
        else
        {
            anim.Play("Idle");
        }
    }

    IEnumerator Grow()
    {
        for (float i = 1; i < 1.1f; i += 0.005f)
        {
            Vector3 localScale = transform.localScale;
            localScale.y = i;
            transform.localScale = localScale;
            yield return new WaitForSeconds(0.005f);
        }
    }
    IEnumerator Shrink()
    {
        for (float i = 1.1f; i > 1f; i -= 0.005f)
        {
            Vector3 localScale = transform.localScale;
            localScale.y = i;
            transform.localScale = localScale;
            yield return new WaitForSeconds(0.005f);
        }
    }
}
