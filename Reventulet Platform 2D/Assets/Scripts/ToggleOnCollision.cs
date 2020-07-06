using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOnCollision : MonoBehaviour
{
    public GameObject ObjectToToggle;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)
    {
        ObjectToToggle.SetActive(!ObjectToToggle.activeInHierarchy);
    }
}
