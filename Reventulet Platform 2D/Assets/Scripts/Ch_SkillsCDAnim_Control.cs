using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Ch_SkillsCDAnim_Control : MonoBehaviour
{
    public Slider sliderCD;
    public float cooldown = 10.0f;
    private float resetCooldown;
    public Animator animationToChange;
    public string NameParameterBool;
    public Animator CDshakeAnim;
    private bool shake = false;
    private bool anim = false;
    public int LvNeedToUnlock;
    public UnityEvent IfItsLocked;
    private bool MelaSelvatica;
    public float AppleDuration = 20f;
    private float AppleDurationReset;


    // Start is called before the first frame update
    private void Awake()
    {
        var cooldownReduction = PlayerPrefs.GetInt("CoinSnowFlake") / 100;
        
            if(cooldownReduction > cooldown / 2)
            {
                cooldown = cooldown / 2;
            }
            else
            {
                cooldown = cooldown - cooldownReduction;
            }          
        
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("UnlockedLv") < LvNeedToUnlock)
        {
            if (IfItsLocked != null) IfItsLocked.Invoke();
        }
        sliderCD.maxValue = cooldown;
        sliderCD.value = 0;
        resetCooldown = cooldown;
        AppleDurationReset = AppleDuration;
    }

    public void EatApple()
    {
        MelaSelvatica = true;
    }

    public void ActiceSkills()
    {
        if (cooldown <= 0.0f)
        {
             animationToChange.SetBool(NameParameterBool, true);
            anim = true;
            if (MelaSelvatica)
            {
                cooldown = resetCooldown - 3;
            }
            else
            {
                cooldown = resetCooldown;
            }
        }
        else
        {
            CDshakeAnim.SetBool("Shake", true);
            shake = true;
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        sliderCD.value = cooldown;
        if (cooldown > 0.0f)
        {
            animationToChange.SetBool(NameParameterBool, false);
            cooldown -= Time.deltaTime;
        }
        if (MelaSelvatica)
        {
            AppleDuration -= Time.deltaTime;
            if(AppleDuration < 0.0f)
            {
                MelaSelvatica = false;
                AppleDuration = AppleDurationReset;
            }
        }
        if (anim)
        {
            anim = false;
            animationToChange.SetBool(NameParameterBool, false);
        }
        if(shake)
        {
            shake = false;
            CDshakeAnim.SetBool("Shake", false);
        }
    }
}
