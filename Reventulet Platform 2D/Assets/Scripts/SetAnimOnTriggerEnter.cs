using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimOnTriggerEnter : MonoBehaviour
{
    public Animator animationToChange;
    public string NameParameterBool;

    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("light"))
        {
            animationToChange.SetBool(NameParameterBool, true);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("light"))
        {
            animationToChange.SetBool(NameParameterBool, false);
        }

    }
}
