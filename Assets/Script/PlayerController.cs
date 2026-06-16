using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb2d;
    public Weapon[] weapons;
    public float health = 10f;
    public float fireRate = 1f;
    public double timer = 0;
    public float turningSpeed = 1f;
    public float decelerationRate;
    private float rotationInput;
    private float moveInput;
    [SerializeField] private GameManager gameManager;
    public Slider movingSpeedInfo;
    public Slider turningSpeedInfo;
    public Slider decelerationRateInfo;
    private float maxSpeed = 100f;
   // [SerializeField] private TMP_Text reloadText;

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
        rotationInput = -Input.GetAxis("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //moveDirection = new Vector2(moveX, moveY).normalized;
        //moveDirection.y += Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //transform.position = moveDirection;  
        MoveandRotate();
        Attack();
        moveSpeed = movingSpeedInfo.value;  
        turningSpeed = turningSpeedInfo.value;  
        decelerationRate = decelerationRateInfo.value;              

    }
    bool isMoved = false;
    private void MoveandRotate()
    {   
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(0, 0, turningSpeed);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(0, 0, -turningSpeed);
        //}
        float rotationAmount = rotationInput * turningSpeed * Time.fixedDeltaTime;
        rb2d.MoveRotation(rb2d.rotation + rotationAmount);


        if (Input.GetKeyDown(KeyCode.W))
        {
            isMoved = true;
            Debug.Log("key pressed");
       
        }

        if(isMoved == true)
        {
            rb2d.velocity = transform.up * moveSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb2d.velocity = Vector2.Lerp(rb2d.velocity, Vector2.zero, decelerationRate * Time.fixedDeltaTime);
            isMoved = false;                

        }
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && timer <= 0)
        {
            if (gameManager.isPaused == true)
            {
                return;
            }
            else
            {
                foreach (Weapon weapon in weapons)
                {
                    weapon.Fire();
                    timer = fireRate;
                }
            }
        }
        else
        {
            timer -= Time.deltaTime;                    
        }
        //ReloadText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            health--;
        }
 
    }          

    //private void ReloadText()
    //{

    //    timer = Math.Round(timer, 2);
    //    if(timer > 0)
    //    {
    //        reloadText.gameObject.SetActive(true);                  
    //        reloadText.text = timer.ToString() +"\nReloading Cannons";
    //    }
    //    else
    //    {
    //        reloadText.gameObject.SetActive(false);                             
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //}

    private void FixedUpdate()
    {
       
        //rb2d.velocity = new Vector2(0, moveDirection.y * moveSpeed);
            
      /*  Vector2 aimDirection = mousePosition - rb2d.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = aimAngle;*/


    }
}
