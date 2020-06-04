using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpCount : MonoBehaviour
{
    private int Hp;
    public int StartHp;
    private int Death = 0;
    public Animator animationToChange;
    public Slider healthBar;
    public bool canTakeDMG = true;


    public string NameParameterBool;




    void Start()
    {
        Hp = StartHp;
        healthBar.maxValue = StartHp;
        healthBar.value = Hp;
    }
   
    public void TakeDamage(int amount)
    {
        if (canTakeDMG)
        {
            Hp -= amount; 
        }
              
    }
 
    void Update()
    {
        healthBar.value = Hp;
        if (Hp <= Death)
        {
            animationToChange.SetBool(NameParameterBool, true);           
        }
    }    
}
