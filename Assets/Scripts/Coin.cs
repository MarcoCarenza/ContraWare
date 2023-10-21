using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    GameManager GM;
    //Health, bomb, coins, timer, 
    public float timer= 2f;

    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Awake()
    {
        GM  = FindObjectOfType<GameManager>();
        FindObjectOfType<AudioManagement>().Play("coinSpawn");
    }

    void Update()
    {
        //Timer(timer);
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {

            Debug.Log("Coin gone");
            Destroy(gameObject);
            timer += 2f;
        }
    }

    void Pickup(Collider2D player)
    {

        //   Debug.Log("pick");

        // Debug.Log(currentHP);
        FindObjectOfType<AudioManagement>().Play("coinPickUp");
        GM.AddPoints(1000);
        // int newHP = hp.GetHP();
        //Debug.Log(newHP);

        Destroy(gameObject);

    }

    void Timer(float timeLeft)
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }else
        {
            
            Debug.Log("Coin gone");
            Destroy(gameObject);
            timeLeft += timer;
        }
    }

}
