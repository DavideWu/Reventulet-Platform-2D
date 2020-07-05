using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAfterTime : MonoBehaviour
{
    public float lifeTime = 1.0f;
    private float timer = 0.0f;
    public GameObject ObjectToToggle;
    // Start is called before the first frame update

    void OnEnable()
    {
        timer = 0f; 
    }

    void LateUpdate()
    {
        timer += Time.deltaTime;
        if(timer > lifeTime)
        {
           ObjectToToggle.SetActive(false);
            timer = timer - lifeTime;
        }

    }
}
