using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ColorChange : MonoBehaviour
{
    //playerValue is the color of the player, Red is 0, Green is 1, Blue is 2.
    public int playerValue;

    //Red 0
    public Sprite playerColor0;
    //Green 1
    public Sprite playerColor1;
    //Blue 2
    public Sprite playerColor2;
    //Sprite renderer of the player
    public SpriteRenderer playerRenderer;
    //Call to animator
    public Animator anim;

    float canSwapColor= 1f;
    float swapRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //player model starts as blue
        playerValue = 0;
        playerRenderer.sprite = playerColor2;
    }

    // Update is called once per frame
    void Update()
    {

        if (PauseMenu.GameIsPaused) { }
        else
        {
           


            //Let's say Q increases playerValue
            if (Input.GetKeyDown("e") || Input.GetKeyDown("space") && Time.time > canSwapColor)
            {
                // Debug.Log("Pressed E !");
                //If we are at the end of the color values loop, we cycle back to 0
                if (playerValue == 2)
                {
                    playerValue = 0;
                }
                //If not, we just increase the value
                else
                {
                    playerValue += 1;
                }
                //We then change the player's sprite according to the new value with the color associated
                ChangePlayerColor(playerValue);
                canSwapColor = Time.time + swapRate;
            }
            //Let's say E decreases playerValue
            if (Input.GetKeyDown("q"))
            {
                // Debug.Log("Pressed Q !");
                //If we are at the begining of the color values loop, we cycle back to 2
                if (playerValue == 0)
                {
                    playerValue = 2;
                }
                //If not, we just decrease the value
                else
                {
                    playerValue -= 1;
                }
                //We then change the player's sprite according to the new value with the color associated
                ChangePlayerColor(playerValue);
            }
        }
    }

    public void ChangePlayerColor(int pValue)
    {
        //Red
        if (pValue == 0)
        {
            playerRenderer.sprite = playerColor0;

            FindObjectOfType<AudioManagement>().Play("Red");

           // Debug.Log("Red sfx");
        }

        //Green
        else if (pValue == 1)
        {
            playerRenderer.sprite = playerColor1;

            FindObjectOfType<AudioManagement>().Play("Green");

            //Debug.Log("Green sfx");
        }

        //Blue
        else if (pValue == 2)
        {
            playerRenderer.sprite = playerColor2;

            FindObjectOfType<AudioManagement>().Play("Blue");

           // Debug.Log("Blue sfx");
        }

        anim.SetInteger("playerValue", pValue);
    }

    //Some other methods just in case you need them

    //This one returns the value as an int
    public int GetPlayerColorValue()
    {
       // if(playerValue == 0) Debug.Log("Player is red from value");
       // if (playerValue == 1) Debug.Log("Player is green from value");
       // if (playerValue == 2) Debug.Log("Player is blue from value");
        return playerValue;
    }

    //This one returns the value as a sprite
    public Sprite GetPlayerColorSprite()
    {
        return playerRenderer.sprite;
    }

 
}


