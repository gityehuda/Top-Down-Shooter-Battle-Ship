using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
   // public Rigidbody2D rb2d;
    public Weapon weapon;
    public Weapon weapon2;
    private int health = 10;

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

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //  moveDirection = new Vector2(moveX, moveY).normalized;
        //moveDirection.y += Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //transform.position = moveDirection;  
        MoveandRotate();
        Attack();                       

        if(health < 0)
        {
            Destroy(gameObject);
        }

    }

    private void MoveandRotate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, 0.5f);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -0.5f);
        }    

        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }

    }

    private void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
           
              weapon.Fire();
            weapon2.Fire();
          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            health--;
        }
    }

    private void FixedUpdate()
    {
       
            
      /*  Vector2 aimDirection = mousePosition - rb2d.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = aimAngle;*/


    }
}
