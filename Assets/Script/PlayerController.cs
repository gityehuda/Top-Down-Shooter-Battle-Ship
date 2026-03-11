using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb2d;
    public Weapon weapon;

    Vector2 moveDirection;
    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, 0.01f);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -0.01f);
        }    
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    

    }

    private void FixedUpdate()
    {
      /*  rb2d.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 aimDirection = mousePosition - rb2d.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = aimAngle;*/


    }
}
