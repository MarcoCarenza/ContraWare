using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickup : MonoBehaviour
{

    GameManager GM;
    public float addedTime = 10f;//time it adds
    public float timer = 2f;//time till it despawns

    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        FindObjectOfType<AudioManagement>().PlayOneShot("timeSpawn");
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

            Debug.Log("Clock gone");
            Destroy(gameObject);
            timer += 2f;
        }
    }

    void Pickup(Collider2D player)
    {
         float time = addedTime; 
        GM.addToTimer(10f);
        Debug.Log("Added " + time + " time");

        FindObjectOfType<AudioManagement>().Play("TimePickUp");
       
        Destroy(gameObject);

    }


    void Timer(float timeLeft)
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {

            Debug.Log("Clock gone");
            Destroy(gameObject);
            timeLeft += timer;
        }
    }
}
