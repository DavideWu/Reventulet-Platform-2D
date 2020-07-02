using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLWorldSpeed : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("DifficultyLv") == 1)
        {
            anim.speed = 1.0f;
        }
        else if (PlayerPrefs.GetInt("DifficultyLv") == 2)
        {
            anim.speed = 1.25f;
        }
        else if (PlayerPrefs.GetInt("DifficultyLv") == 3)
        {
            anim.speed = 1.5f;
        }
        else if (PlayerPrefs.GetInt("DifficultyLv") == 4)
        {
            anim.speed = 1.75f;
        }
    }
}
