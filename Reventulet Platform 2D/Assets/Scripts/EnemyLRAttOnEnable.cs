using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLRAttOnEnable : MonoBehaviour
{
    private SpriteRenderer render;
    public GameObject AttR;
    public GameObject AttL;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (render.flipX == false)
        {
            AttR.SetActive(true);
            AttL.SetActive(false);
        }
        else if (render.flipX == true)
        {
            AttL.SetActive(true);
            AttR.SetActive(false);
        }
    }

    private void stun()
    {
        AttR.SetActive(false);
        AttL.SetActive(false);
    }

    private void OnDisable()
    {
        stun();
    }
}
