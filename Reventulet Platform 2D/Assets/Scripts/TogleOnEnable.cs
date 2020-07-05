using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogleOnEnable : MonoBehaviour
{
    public GameObject ObjectToToggle;
    // Start is called before the first frame update
    void OnEnable()
    {
        ObjectToToggle.SetActive(!ObjectToToggle.activeInHierarchy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
