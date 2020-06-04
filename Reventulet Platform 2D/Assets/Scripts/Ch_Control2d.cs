using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch_Control2d : MonoBehaviour
{
    public float speed = 15;
    public float jumpF = 300f;
    private Rigidbody2D rb2d;
    [Range(0.1f , 2f)]
    public float groundDetectDist =0.5f;
    public string jumpButton = "Jump";
    public Transform groundedRay;


    private SpriteRenderer render;
    private float startSpeed;

    void Start()
    {
        startSpeed = speed;
        render = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void jump ()
    {
        RaycastHit2D grounded = Physics2D.Raycast(groundedRay.position, Vector2.down, groundDetectDist);
        if (grounded.collider != null)
        {
            rb2d.AddForce(new Vector2(0f, jumpF));
        }   

    }

    void FixedUpdate()
    {
        
        float moveHorizontal = SimpleInput.GetAxis("Horizontal");

        float moveVertical = SimpleInput.GetAxis("Vertical");

        Vector2 movementH = new Vector2(moveHorizontal, moveVertical / 4);

        rb2d.AddForce(movementH * speed);
        
        if (moveHorizontal < 0)
        {
            render.flipX = true;

        }
        else if (moveHorizontal > 0)
        {
            render.flipX = false;
        }
        
        if(moveVertical < 0)
        {
            speed = speed / 2;
        }
        else
        {
            speed = startSpeed;
        }

    }

}
