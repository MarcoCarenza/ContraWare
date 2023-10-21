using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
       
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //makes it that u start at max hp
       if(tag == "CPU" || tag == "Player") healthBar.setMaxHealth(maxHealth); //displays HP bar at max
    }

    // Update is called once per frame
    void Update()
    {

        if (tag == "Player" || tag == "CPU" & currentHealth <= 0 )
        {
   
        }else if (currentHealth <= 0)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
                
    }

    public void TakeDamage(int Dmg)
    {
        currentHealth -= Dmg;
        if (tag == "CPU" || tag == "Player") healthBar.setHealth(currentHealth);
    }

    public void HealDamage(int Heal)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += Heal;
            healthBar.setHealth(currentHealth);
        }
       
    }

    public int GetHP()
    {
        return currentHealth;
    }

}
