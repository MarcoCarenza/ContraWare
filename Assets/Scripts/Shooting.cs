using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    
    


    // Update is called once per frame
    void Update()
    {

        if (PauseMenu.GameIsPaused)
        { }
        else 
        {
             if (Input.GetButtonDown("Fire1"))
              {
                  Shoot();
              }
        }
    }
    

    

    //method that does the shooting
    void Shoot()
    {
        //creating the bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //bullet in question
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //making bullet fly
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        //makes bullet sound
        FindObjectOfType<AudioManagement>().Play("Projectile");
    }

  // void onCollisionEnter2D(Collision2D collision)
   // {

       // 

    //}
}
