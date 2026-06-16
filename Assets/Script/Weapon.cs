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
   private float initialduration = 0.08f;
    private float FireEffectduration;
    [SerializeField] private Animator animator; 
    

    private void Awake()
    {
                      fireEffect = Instantiate(MuzzleEffect);
    }
    GameObject fireEffect;
    // Start is called before the first frame update
    void Start()
    {
       
        fireEffect.transform.parent = firePoint;
        fireEffect.SetActive(true);
        animator = fireEffect.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //FireEffectLifetime();
    }

    public void Fire()
    {
        //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // GameObject bulletObject = ObjectPooling.instance.GetObject();
      

        Bullet bullet = ObjectPooling.instance.GetObject<Bullet>();
        if (transform.parent.tag == "Enemy")
        {
            bullet.gameObject.tag = "EnemyBullet";
        }
        else
        {
            bullet.gameObject.tag = "Bullet";
        }


        animator.SetTrigger("StartEffect");
            bullet.SetPosition(firePoint.position);
            bullet.SetRotation(firePoint.rotation);
        //FireEffectduration = initialduration;   
        //fireEffect.SetActive(true);        
        //fireEffect.GetComponent<Animator>().enabled = true;
        //FireEffectLifetime(fireEffect);
       // SpawnEffect();
        Debug.Log(fireEffect.name);
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

    private void FireEffectLifetime(GameObject muzzleeffect)
    {
        if(muzzleeffect != null)
        {
            FireEffectduration -= Time.deltaTime;
            if(FireEffectduration < 0)
            {
                muzzleeffect.SetActive(false);     
            }
        }
    }

    void SpawnEffect()
    {
        GameObject flash = EffectPool.instance.GetFlash();  
        flash.transform.position = firePoint.position;
        flash.transform.rotation = firePoint.rotation;

        GameObject smoke = EffectPool.instance.GetSmoke();  

        smoke.transform.position = firePoint.position;
        smoke.transform.rotation = firePoint.rotation;  

    }

}
