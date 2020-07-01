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
            if(AppleDuration < 0.0f)
            {
                MelaSelvatica = false;
                AppleDuration = AppleDurationReset;
            }
        }
    }
}
