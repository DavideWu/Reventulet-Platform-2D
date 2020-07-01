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
    private void OnEnable()
    {
        if (render.flipX == false)
        {
            AttR.SetActive(true);
        }
        else
        {
            AttL.SetActive(true);
        }
    }

    private void OnDisable()
    {
        AttR.SetActive(false);
        AttL.SetActive(false);
    }
}
