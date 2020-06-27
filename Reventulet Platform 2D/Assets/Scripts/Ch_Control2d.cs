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
    private Transform groundedRay;

    private Animator anim;
    private float startSpeed;
    private bool m_FacingRight = true;

    void Start()
    {
        startSpeed = speed;
        groundedRay = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void jump ()
    {
        RaycastHit2D grounded = Physics2D.Raycast(groundedRay.position, Vector2.down, groundDetectDist);
        if (grounded.collider != null)
        {
            rb2d.AddForce(new Vector2(0f, jumpF));
        }   

    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Update()
    {
        RaycastHit2D grounded = Physics2D.Raycast(groundedRay.position, Vector2.down, groundDetectDist);
        if (grounded.collider != null)
        {
            anim.SetBool("Grounded", true);
        }
        else
        {
            anim.SetBool("Grounded", false);
        }
    }

    void FixedUpdate()
    {

        float moveHorizontal = SimpleInput.GetAxis("Horizontal");

        Vector2 movementH = new Vector2(moveHorizontal ,0);

        rb2d.AddForce(movementH * speed);
        if (moveHorizontal < 0 && m_FacingRight)
        {
            Flip();
        }
        else if (moveHorizontal > 0 && !m_FacingRight)
        {
            Flip();
        }

        if (moveHorizontal < 0)
        {
            anim.SetBool("H_Move", true);
        }
        else if (moveHorizontal > 0)
        {
            anim.SetBool("H_Move", true);
        }
        else
        {
            anim.SetBool("H_Move", false);
        }

        bool Jump = SimpleInput.GetButtonUp("Jump");
        if (Jump)
        {
            jump();
        }
    }

}
