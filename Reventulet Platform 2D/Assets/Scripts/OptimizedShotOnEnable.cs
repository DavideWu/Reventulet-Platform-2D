using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizedShotOnEnable : MonoBehaviour
{
    public GameObject Bullet;
    public Rigidbody2D inserireStessoGObg;
    public float ProjectileSpeed = -20f;

    // Start is called before the first frame update

    void OnEnable()
    {

            Bullet.transform.position = transform.position;
            Bullet.transform.rotation = transform.rotation;
            Bullet.SetActive(!Bullet.activeInHierarchy);
            inserireStessoGObg.velocity = transform.TransformDirection(new Vector2(ProjectileSpeed, 0f));

    }
}
