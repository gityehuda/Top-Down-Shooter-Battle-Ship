using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    Vector3 mousePosition;
   // public Rigidbody2D rb2d;
    private float rotationSpeed = 100f;
   // public Transform pivotPoint;


    // Start is called before the first frame update
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 aimDirection = mousePosition - transform.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, aimAngle);
    }
}
