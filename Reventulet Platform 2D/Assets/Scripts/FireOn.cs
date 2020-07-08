using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOn : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (PlayerPrefs.GetInt("Fire") == 12)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
