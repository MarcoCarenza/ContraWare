using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int enemyValue; //color of enemy
    public int enemyType; //type of enemy
    public int speed;
    public HP hp;
    int health;  // = hp.GetHP();
    
    // public gameObject gO;

    public Sprite Red; //enemyValue = 0
    public Sprite Green; //enemyValue = 1
    public Sprite Blue; //enemyValue = 2

    private SpriteRenderer spriteRenderer;
   // HP hp;


    // Start is called before the first frame update
    void Start()
    {
        enemyValue = Random.Range(0, 3);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
       
        //hp = gameObject.GetComponent<HP>();
    }

    // Update is called once per frame
    void Update()
    {
      SetSprite();
       // GivePoints();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.collider.tag == "CPU" || collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<HP>().TakeDamage(1);
            Destroy(gameObject);
        }
       
    }

    private void SetSprite()
    {
        if (enemyValue == 0)
        {
            spriteRenderer.color = new Color(255, 0, 0);
        }
        else if (enemyValue == 1)
        {
            spriteRenderer.color = new Color(0, 255, 0); ;
        }
        else if (enemyValue == 2)
        {
            spriteRenderer.color = new Color(0, 0, 255); ;
        }
    }

    public int GetEnemyValue()
    { 
        return enemyValue; 
    }

    

}
