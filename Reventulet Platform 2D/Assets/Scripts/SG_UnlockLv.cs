using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_UnlockLv : MonoBehaviour
{
    public int LvDone;
    public void addUnlockedLv()
    {
        if (PlayerPrefs.GetInt("UnlockedLv") == LvDone)
        {
            PlayerPrefs.SetInt("UnlockedLv", PlayerPrefs.GetInt("UnlockedLv") + 1);
        }
    }
}
