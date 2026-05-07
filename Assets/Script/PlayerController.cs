using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb2d;
    public Weapon[] weapons;
    public float health = 10f;
    public float fireRate = 1f;
    private float timer = 0;
    public float turningSpeed = 0.1f;
    public float decelerationRate;

    Vector2 moveDirection;
    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();                                                                     
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
            transform.Rotate(0, 0, -turningSpeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            
                rb2d.velocity = transform.up * moveSpeed * Time.fixedDeltaTime;
      
            Debug.Log("key pressed");
        }
        else
        {
            decelerationRate = 0.7f;        
            rb2d.velocity = Vector2.Lerp(rb2d.velocity, Vector2.zero, decelerationRate * Time.fixedDeltaTime);
        }

    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && timer <= 0)
        {
           foreach(Weapon weapon in weapons)
            {
                weapon.Fire();
                timer = fireRate;
            }
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
