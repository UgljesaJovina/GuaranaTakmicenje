using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    Camera mainCamera;
    Vector2 mousePosition;
    [SerializeField] SpriteRenderer weaponRenderer;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mousePosition.Normalize();

        float zRot = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, zRot);
    }
}
