using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLog : MonoBehaviour
{


    // Update is called once per frame
    void Start()
    {
        Debug.Log("unlockedLv :" + PlayerPrefs.GetInt("UnlockedLv"));
        Debug.Log("DifficultyLv :" + PlayerPrefs.GetInt("DifficultyLv"));
    }
}
