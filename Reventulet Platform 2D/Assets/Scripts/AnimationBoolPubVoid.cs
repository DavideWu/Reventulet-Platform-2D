using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBoolPubVoid : MonoBehaviour
{
    public Animator animationToChange;
    public string NameParameterBool;
    public bool activeB;
    // Start is called before the first frame update
    public void ActiveAnimation()
    {
        animationToChange.SetBool(NameParameterBool, activeB);
    }
}
