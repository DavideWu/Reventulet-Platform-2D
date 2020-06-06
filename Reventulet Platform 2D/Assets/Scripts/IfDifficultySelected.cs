using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfDifficultySelected : MonoBehaviour
{
    public GameObject objToActive;
    public GameObject objToDeactive;

    void Start()
    {
        if (PlayerPrefs.GetInt("DifficultyLv") > 0)
        {
            objToActive.SetActive(!objToActive.activeInHierarchy);
            objToDeactive.SetActive(!objToDeactive.activeInHierarchy);
        }
    }
}
