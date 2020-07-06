using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizedShootExplosion_UseToggle : MonoBehaviour
{
    public GameObject BulletExplosion;
    
   

    private void OnCollisionEnter2D(Collision2D other)
    {
        BulletExplosion.transform.position = transform.position;
        BulletExplosion.SetActive(!BulletExplosion.activeInHierarchy);
        

    }
}
