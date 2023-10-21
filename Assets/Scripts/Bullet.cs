using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    ColorChange player;
    GameManager gm;
    HP hp;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<ColorChange>();
    }

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "CPU")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
            Destroy(gameObject);
            collision.collider.GetComponent<HP>().TakeDamage(1);
            FindObjectOfType<AudioManagement>().Play("enemyHitWrong");
        }

        if (collision.collider.tag == "Enemy" && player.GetPlayerColorValue() == collision.collider.GetComponent<Enemy>().GetEnemyValue())
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
            Destroy(gameObject);
        
            int hp = collision.collider.GetComponent<HP>().GetHP();
            collision.collider.GetComponent<HP>().TakeDamage(1);

            FindObjectOfType<AudioManagement>().Play("enemyHit");

            if (hp <= 1)
                {gm.AddPoints(100); }

            
        }else if(collision.collider.tag == "Enemy" && player.GetPlayerColorValue() != collision.collider.GetComponent<Enemy>().GetEnemyValue())
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
            Destroy(gameObject);
            FindObjectOfType<AudioManagement>().Play("enemyHitWrong");
        }
        else {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
            Destroy(gameObject);
            
        }
        

    }
}
