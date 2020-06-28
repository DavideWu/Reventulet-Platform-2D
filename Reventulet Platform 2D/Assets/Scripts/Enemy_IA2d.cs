using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_IA2d : MonoBehaviour
{
    public float speed;
    [Range(0, 10f)]
    public float closeStopDist;

    public Transform rightRayStart;
    [Range(0.1f, 100f)]
    public float RayDist;

    public Transform leftRayStart;
    [Range(0.1f, 2f)]
    public float groundDetectDist = 0.5f;
    [Range(0.1f, 2f)]
    public float obstacleDetectDist = 0.5f;
    [Range(0, 100)]
    public int turnChance;
    [Range(0.1f, 10f)]
    public float turnDecisionCD = 5f;

    private bool faceRight;
    private bool detectTarget;
    private bool randomTurnDecision;
    private bool idleDecision;
    private Transform target;
    private SpriteRenderer render;
    private int RandomAction;
    private float timer;
    private Animator Anim;

    void Start ()
    {
        render = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit2D rightRay = Physics2D.Raycast(rightRayStart.position, Vector2.right, RayDist);
        RaycastHit2D leftRay = Physics2D.Raycast(leftRayStart.position, Vector2.left, RayDist);
        RaycastHit2D rightGrounded = Physics2D.Raycast(rightRayStart.position, Vector2.down, groundDetectDist);
        RaycastHit2D leftGrounded = Physics2D.Raycast(leftRayStart.position, Vector2.down, groundDetectDist);
        RaycastHit2D rightObstacle = Physics2D.Raycast(rightRayStart.position, Vector2.right, obstacleDetectDist);
        RaycastHit2D leftObstacle = Physics2D.Raycast(leftRayStart.position, Vector2.left, groundDetectDist);
         timer += Time.deltaTime;
        if (timer > turnDecisionCD)
        {
            RandomAction = Random.Range(1, 100);
            timer = timer - turnDecisionCD;

            if (RandomAction <= turnChance)
            {
                randomTurnDecision = true;
                if (detectTarget == false && rightGrounded.collider == true && leftGrounded.collider == true && rightObstacle.collider == false && leftObstacle.collider == false)
                {
                    if(render.flipX == false)
                    {
                        render.flipX = true;
                    }
                    else
                    {
                        render.flipX = false;
                    }
                }
            }
            else
            {
                randomTurnDecision = false;
            }

        }

        if (randomTurnDecision)
        {
            if (rightRay.collider != null && rightRay.collider.CompareTag("Player") && rightGrounded.collider == true && leftGrounded.collider == true)
            {
                if (Vector2.Distance(transform.position, target.position) > closeStopDist)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, (speed - (speed * 2)) * Time.deltaTime);
                    render.flipX = true;
                    detectTarget = true;
                    Anim.SetBool("Idle", false);
                }
                else
                {
                    Anim.SetBool("Idle", true);
                }
            }
            else if (leftRay.collider != null && leftRay.collider.CompareTag("Player") && rightGrounded.collider == true && leftGrounded.collider == true)
            {
                if (Vector2.Distance(transform.position, target.position) > closeStopDist)
                {
                    render.flipX = false;
                    transform.position = Vector2.MoveTowards(transform.position, target.position, (speed - (speed * 2)) * Time.deltaTime);
                    detectTarget = true;
                    Anim.SetBool("Idle", false);
                }
                else
                {
                    Anim.SetBool("Idle", true);
                }

            }
            else if (rightRay.collider != null && rightRay.collider.CompareTag("Player") && rightGrounded.collider == false)
            {
                idleDecision = true;
                Anim.SetBool("Idle", true);
            }
            else if (leftRay.collider != null && leftRay.collider.CompareTag("Player") && leftGrounded.collider == false)
            {
                idleDecision = true;
                Anim.SetBool("Idle", true);
            }
            else
            {
                detectTarget = false;
                Anim.SetBool("Idle", false);
            }


        }
        else
        {
            if (rightRay.collider != null && rightRay.collider.CompareTag("Player") && rightGrounded.collider == true && leftGrounded.collider == true)
            {
                if (Vector2.Distance(transform.position, target.position) > closeStopDist)
                {
                   transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                   render.flipX = false;
                   detectTarget = true;
                    Anim.SetBool("Idle", false);
                }
                else
                {
                    Anim.SetBool("Idle", true);
                }
            }
            else if (leftRay.collider != null && leftRay.collider.CompareTag("Player") && rightGrounded.collider == true && leftGrounded.collider == true)
            {
                if (Vector2.Distance(transform.position, target.position) > closeStopDist)
                {
                   render.flipX = true;
                   transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                   detectTarget = true;
                    Anim.SetBool("Idle", false);
                }
                else
                {
                    Anim.SetBool("Idle", true);
                }
            }
            else if (rightRay.collider != null && rightRay.collider.CompareTag("Player") && rightGrounded.collider == false)
            {
                idleDecision = true;
                Anim.SetBool("Idle", true);
            }
            else if (leftRay.collider != null && leftRay.collider.CompareTag("Player") && leftGrounded.collider == false)
            {
                idleDecision = true;
                Anim.SetBool("Idle", true);
            }
            else
            {
                detectTarget = false;
                Anim.SetBool("Idle", false);
            }

        }
        

        
        if (detectTarget == false)
        {
            if (render.flipX == false && idleDecision == false)
            {
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else if (render.flipX == true && idleDecision == false)
            {
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            if (rightGrounded.collider == false && leftObstacle.collider == false)
            {
                 if (render.flipX == false)
                 {
                         render.flipX = true;
                 }
            }
            if (leftGrounded.collider == false && rightObstacle.collider == false)
            {
                if (render.flipX == true)
                {
                         render.flipX = false;
                }
            }
            if (rightObstacle.collider == true && leftGrounded.collider == true)
            {
                if (render.flipX == false)
                {
                        render.flipX = true;
                }
            }
            if (leftObstacle.collider == true && rightGrounded.collider == true)
            {
                if (render.flipX == true)
                {
                        render.flipX = false;
                }
            }
            if (rightObstacle.collider == true && leftGrounded.collider == false)
            {
                if (render.flipX == false)
                {
                    idleDecision = true;
                    render.flipX = false;
                }
                else
                {
                    render.flipX = false;
                }
            }
            else if (leftObstacle.collider == true && rightGrounded.collider == false)
            {
                if (render.flipX == true)
                {
                    idleDecision = true;
                    render.flipX = true;
                }
                else
                {
                    render.flipX = true;
                }
            }
            else if (rightObstacle.collider == true && leftGrounded.collider == true && leftObstacle.collider == true && rightGrounded.collider == true)
            {
                idleDecision = true;
            }
            else
            {
                idleDecision = false;
            }

        }
    }
}
