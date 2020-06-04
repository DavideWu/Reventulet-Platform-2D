using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHoleOnCollision : MonoBehaviour
{
    public GameObject whiteHole;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.transform.position = whiteHole.transform.position;
    }
}
