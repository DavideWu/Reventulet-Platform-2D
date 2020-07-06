using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColpoGuidato : MonoBehaviour
{
    public string targetTag = "Enemy";
    public float speed;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            transform.position = Vector2.MoveTowards(transform.position, other.transform.position, speed * Time.deltaTime);
        }
    }
}
