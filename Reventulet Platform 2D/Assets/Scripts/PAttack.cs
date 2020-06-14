using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PAttack : MonoBehaviour
{
    public string TagOnTriggerEnter;
    public int DamageMin;
    public int DamageMax;
    private int Damage;


    private void Start()
    {
        if(gameObject.CompareTag("EnemyAtt"))
        {
            DamageMin = DamageMin * PlayerPrefs.GetInt("DifficultyLv");
            DamageMax = DamageMax * PlayerPrefs.GetInt("DifficultyLv");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagOnTriggerEnter))
        {
            Damage = Random.Range (DamageMin, DamageMax);
            other.gameObject.GetComponent<HpCount>().TakeDamage(Damage);
        }
    }

}
