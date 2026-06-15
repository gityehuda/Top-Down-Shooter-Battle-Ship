using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string WeaponID;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public GameObject MuzzleEffect;
   // public GameObject enemyBullet;
    

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // GameObject bulletObject = ObjectPooling.instance.GetObject();
        Instantiate(MuzzleEffect, firePoint.position, firePoint.rotation);

        Bullet bullet = ObjectPooling.instance.GetObject<Bullet>();
        if (transform.parent.tag == "Enemy")
        {
            bullet.gameObject.tag = "EnemyBullet";
        }
        else
        {
            bullet.gameObject.tag = "Bullet";
        }

            bullet.SetPosition(firePoint.position);
            bullet.SetRotation(firePoint.rotation);
            bullet.AddForce(firePoint.up * fireForce);
      

       
               

        // bullet.transform.position = firePoint.position;
        // bullet.transform.rotation = firePoint.rotation;

        // bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

    }

    public void FireEnemyBullet()
    {

            GameObject enemyBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            enemyBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

}
