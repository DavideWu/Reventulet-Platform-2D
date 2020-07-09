using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOptimizers : MonoBehaviour
{
    public GameObject OBJ;
    private Transform target;
    [Range(15f, 30f)]
    public float RenderDist = 15f;
    // Start is called before the first frame update
    void Start()
    {
        OBJ.SetActive(false);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2.Distance(transform.position, target.position) > RenderDist))
        {
            OBJ.SetActive(false);
        }
        else if ((Vector2.Distance(transform.position, target.position) < RenderDist))
        {
            OBJ.SetActive(true);
        }
    }
}
