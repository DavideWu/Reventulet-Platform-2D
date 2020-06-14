using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    private int heal = 20;
    public string TagOnTriggerEnter;
    // Start is called before the first frame update
    void Start()
    {
        heal = heal + (PlayerPrefs.GetInt("CoinSnowFlake") / 100) ;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagOnTriggerEnter))
        {
            other.gameObject.GetComponent<HpCount>().Healing(heal);
        }
    }
}
