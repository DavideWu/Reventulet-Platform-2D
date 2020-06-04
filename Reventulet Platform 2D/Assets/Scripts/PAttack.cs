using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    public string TagOnTriggerEnter;
    public int DamageMin;
    public int DamageMax;
    private int Damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagOnTriggerEnter))
        {
            Damage = Random.Range (DamageMin, DamageMax);
            other.gameObject.GetComponent<HpCount>().TakeDamage(Damage);

        }
    }
}
