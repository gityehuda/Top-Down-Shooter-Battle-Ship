using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    private float moveSpeed = 5f;
    public Rigidbody2D rb2d;
    public Weapon weapon;

    Vector2 moveDirection;
    Vector2 mousePosition;

    void Update()
    {
       
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    
        
    }

    private void FixedUpdate()
    {
        Vector2 aimDirection = mousePosition - rb2d.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = aimAngle;
    }

}

