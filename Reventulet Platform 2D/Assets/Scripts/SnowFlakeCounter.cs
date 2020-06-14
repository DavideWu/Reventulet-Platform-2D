using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowFlakeCounter : MonoBehaviour
{
    public Text snowFlakeCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        snowFlakeCount.text = "X " + PlayerPrefs.GetInt("CoinSnowFlake");
    }
}
