using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    //Health, bomb, coins, timer, 
   

    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Player"))
        {

            Pickup(other);
        }
    }

    void Awake()
    {
        FindObjectOfType<AudioManagement>().Play("heartSpawn");
    }

    void Pickup(Collider2D player)
    {

     //   Debug.Log("pick");

        HP hp = player.GetComponent<HP>();
        int currentHP = hp.GetHP();
        // Debug.Log(currentHP);
        FindObjectOfType<AudioManagement>().Play("Heal");
        hp.HealDamage(1);
       // int newHP = hp.GetHP();
        //Debug.Log(newHP);

       Destroy(gameObject);

    }
}
