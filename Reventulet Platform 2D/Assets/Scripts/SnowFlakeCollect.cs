using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlakeCollect : MonoBehaviour
{
    private int RandomAppear;
    public GameObject ObjectToToggle;

    private void Start()
    {
        RandomAppear = Random.Range(0, 30);
        if (PlayerPrefs.GetInt("DifficultyLv") > RandomAppear)
        {
            ObjectToToggle.SetActive(!ObjectToToggle.activeInHierarchy);
        }
    }
    // Start is called before the first frame update
    public void takeSnowCoin()
    {
        PlayerPrefs.SetInt("CoinSnowFlake", PlayerPrefs.GetInt("CoinSnowFlake") + 1);
    }
}
