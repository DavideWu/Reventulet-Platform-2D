using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Scatto : MonoBehaviour
{
    public float scattoF = 20f;
    public Slider sliderCD;
    public float cooldown = 10.0f;
    private float resetCooldown;
    private Rigidbody2D rb2d;
    private SpriteRenderer render;

    public Animator animationToChange;
    public string NameParameterBool;

    public int LvNeedToUnlock;
    public UnityEvent IfItsLocked;

    private bool MelaSelvatica;
    public float AppleDuration = 20f;
    private float AppleDurationReset;

    private void Awake()
    {
        var cooldownReduction = PlayerPrefs.GetInt("CoinSnowFlake") / 100;
        if (cooldownReduction > cooldown / 2)
        {
            cooldown = cooldown / 2;
        }
        else
        {
            cooldown = cooldown - cooldownReduction;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("UnlockedLv") < LvNeedToUnlock)
        {
            if (IfItsLocked != null) IfItsLocked.Invoke();
        }
        
        
            sliderCD.maxValue = cooldown;
            sliderCD.value = cooldown;
            render = GetComponent<SpriteRenderer>();
            rb2d = GetComponent<Rigidbody2D>();
            resetCooldown = cooldown;
        
    }

    public void EatApple()
    {
        MelaSelvatica = true;
    }

    public void sprint()
    {
        if (cooldown <= 0.0f)
        {
            animationToChange.SetBool(NameParameterBool, true);
            if (render.flipX == false)
               {
                rb2d.velocity = transform.TransformDirection(new Vector2(scattoF, 0f));
               }
               else
               {
                rb2d.velocity = transform.TransformDirection(new Vector2(scattoF - (scattoF * 2), 0f));
               }
            if (MelaSelvatica)
            {
                cooldown = resetCooldown - 3;
            }
            else
            {
                cooldown = resetCooldown;
            }
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (cooldown > 0.0f)
        {
            animationToChange.SetBool(NameParameterBool, false);
            cooldown -= Time.deltaTime;
            sliderCD.value = cooldown;
        }
        if (MelaSelvatica)
        {
            AppleDuration -= Time.deltaTime;
            if (AppleDuration < 0.0f)
            {
                MelaSelvatica = false;
                AppleDuration = AppleDurationReset;
            }
        }
    }
}
