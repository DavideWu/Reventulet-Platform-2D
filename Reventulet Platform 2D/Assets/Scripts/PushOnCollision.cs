using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOnCollision : MonoBehaviour
{
    public float pushV = 5f;
    public float pushH = 5f;

    void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(pushH, pushV));
    }
}

