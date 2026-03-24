using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    private Vector2 mousePosition;
    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 aimDirection = mousePosition - rb2d.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = aimAngle;
    }
}
