using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveText : MonoBehaviour
{
    float time;
    void Start()
    {
        
    }


    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, 776), time);
        time += Time.deltaTime;
    }
}
