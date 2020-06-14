using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public int LvUnlocked = 1;
    public void SaveUnlockedLv()
    {
        PlayerPrefs.SetInt("UnlockedLv", LvUnlocked);
    }

    public int LvDifficulty;
    public void SelectDifficulty()
    {
        PlayerPrefs.SetInt("DifficultyLv", LvDifficulty);
    }

    public int snowFlakeCoin;
    public void SnowFlakeCoin()
    {
        PlayerPrefs.SetInt("CoinSnowFlake", snowFlakeCoin);
    }
}
