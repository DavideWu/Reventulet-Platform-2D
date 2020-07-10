using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteRenderersOPT : MonoBehaviour
{
    private Renderer render;
    private Transform target;
    [Range(20f, 40f)]
    public float RenderDist = 20f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        render = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < RenderDist)
        {
            render.enabled = true;
        }
        else 
        {
            render.enabled = false;
        }
    }
}
