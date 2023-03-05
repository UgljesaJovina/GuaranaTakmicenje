using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = player.position + new Vector3(0, 0, -10);
    }
}
