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

            
                if (action != null) actionExit.Invoke();
            
                

        }
            
    }
    

    private void OnEnable()
    {

           if (action != null)actionOnEnable.Invoke(); 

    }

    private void OnDisable()
    {

            if (action != null) actionOnDisable.Invoke();

    }

}
