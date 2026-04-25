using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb2d;
    public Weapon weapon;
    public Weapon weapon2;
    public int health = 10;
    public float fireRate = 1f;
    private float timer = 0;
    public float turningSpeed = 0.1f;


    Vector2 moveDirection;
    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //  moveDirection = new Vector2(moveX, moveY).normalized;
        //moveDirection.y += Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //transform.position = moveDirection;  
        MoveandRotate();
        Attack();

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void MoveandRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, turningSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, turningSpeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
           rb2d.velocity = transform.right * moveSpeed * Time.deltaTime;
            Debug.Log("key pressed");
        }
        else
        {
            float decelerationRate = 1f;
            rb2d.velocity = Vector2.Lerp(rb2d.velocity, Vector2.zero, decelerationRate * Time.deltaTime);
        }

    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && timer <= 0)
        {
            weapon.Fire();
            weapon2.Fire();
            timer = fireRate;
        }
        else
        {
            timer -= Time.deltaTime;                    
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            health--;
        }
 
    }          

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //}

    private void FixedUpdate()
    {
       
            
      /*  Vector2 aimDirection = mousePosition - rb2d.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = aimAngle;*/


    }
}
