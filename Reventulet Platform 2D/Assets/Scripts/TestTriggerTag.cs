using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TestTriggerTag : MonoBehaviour
{
    public UnityEvent action;
    public UnityEvent actionExit;
    public UnityEvent actionOnEnable;
    public UnityEvent actionOnDisable;
    public string targetTag = "Enemy";
    private float timer = 0.0f;
    public float CTime = 0.1f;

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            if (action != null)action.Invoke();   

        }
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            timer += Time.deltaTime;
            if (timer > CTime)
            {
                if (action != null) actionExit.Invoke();
                timer = timer - CTime;
            }
                

        }
            
    }
    

    private void OnEnable()
    {

        timer += Time.deltaTime;
        if (timer > CTime)
        {
           if (action != null)actionOnEnable.Invoke(); 
            timer = timer - CTime;
        }
        
       
    }

    private void OnDisable()
    {
        timer += Time.deltaTime;
        if (timer > CTime)
        {
            if (action != null) actionOnDisable.Invoke();
            timer = timer - CTime;
        }
        

    }

}
