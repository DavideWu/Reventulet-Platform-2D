using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOptimizers : MonoBehaviour
{
    public GameObject OBJ;
    private Transform target;
    private Renderer render;
    [Range(15f, 30f)]
    public float RenderDist = 15f;
    private bool togle = true;
    // Start is called before the first frame update
    void Start()
    {
        OBJ.SetActive(false);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        render = OBJ.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < RenderDist)
        {
            if(togle)
            {
                OBJ.SetActive(true);
                togle = false;
                
            }
                  
        }
        if (OBJ.gameObject.CompareTag("SceneOBJ") && (Vector2.Distance(transform.position, target.position) > RenderDist))
        {
               render.enabled = false;
               togle = true;
        }
        else if (OBJ.gameObject.CompareTag("SceneOBJ") && (Vector2.Distance(transform.position, target.position) < RenderDist))
        {
            render.enabled = true;
        }
    }
}
