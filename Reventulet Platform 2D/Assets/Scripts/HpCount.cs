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

    public GameObject DamageText;
    public GameObject DamageCanvas;
    public GameObject DamageSpwnZ;
    private Text Damage;
    public Text textHpCount;

    public string NameParameterBool;


    private void Awake()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            StartHp = StartHp * PlayerPrefs.GetInt("DifficultyLv");
        }
        else if(gameObject.CompareTag("Player"))
        {
            if(PlayerPrefs.GetInt("CoinSnowFlake") > StartHp *10)
            {
                StartHp = (StartHp * 10) + 500;
            }
            else
            {
                StartHp = StartHp + (PlayerPrefs.GetInt("CoinSnowFlake") / 10) * 10;
            }           
        }
    }

    void Start()
    {
        Hp = StartHp;
        healthBar.maxValue = StartHp;
        healthBar.value = Hp;
        Damage = DamageText.GetComponent<Text>();
    }
   
    public void TakeDamage(int amount)
    {
        if (canTakeDMG)
        {
            if(amount > Hp)
            {
                Hp = 0;
            }
            else
            {
                Hp -= amount; 
            }
            Damage.text = "" + amount;
            Damage.color = Color.red;
            DamageText.SetActive(true);
            DamageCanvas.gameObject.transform.position = DamageSpwnZ.transform.position;
        }             
    }

    public void Healing(int amount)
    {  
        if(amount > StartHp - Hp)
        {
            Hp = StartHp;
        }
        else
        {
            Hp += amount;  
        }
        Damage.text = "" + amount;
        Damage.color = Color.green;
        DamageText.SetActive(true);
        DamageCanvas.gameObject.transform.position = DamageSpwnZ.transform.position;
    }

    void Update()
    {
        healthBar.value = Hp;
        if (Hp <= Death)
        {
            animationToChange.SetBool(NameParameterBool, true);
        }
        textHpCount.text = StartHp + " / " + Hp;
        
    }    
}
