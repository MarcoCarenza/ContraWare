using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //player momvement
    public float moveSpeed = 5f;

    //player rigidbody
    public Rigidbody2D rb;

    public Animator animator;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;
    GameManager gm;

    // Update is called once per frame
    void Update()
    {
        //inputs in here
        //gets wasd or arrow keys for movement

        if (PauseMenu.GameIsPaused) { }
        else
        {


            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
       
        
        if (movement.x == -1)
        {
           animator.SetBool("Left", true);
        }
        else if (movement.x == 1)
        {
            animator.SetBool("Left", false);
        }


     /*   if (PauseMenu.GameIsPaused)
        {
            FindObjectOfType<AudioManagement>().Play("Hover"); 
        }
        else
        {
            FindObjectOfType<AudioManagement>().Stop("Hover");
        }
     */


    }

    // Update for movement not fixed on fps
    void FixedUpdate()
    {
        // Movement in here

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

    }

    // To play hovering sound
    void Start()
    {
      
        
        
    }


}
