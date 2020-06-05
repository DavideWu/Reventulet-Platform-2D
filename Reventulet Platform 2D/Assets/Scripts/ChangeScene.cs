using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int LvNeedToUnlock;
    public string ScenesName;
    public void changeScene()
    {
        if(LvNeedToUnlock <= PlayerPrefs.GetInt("UnlockedLv"))
        {
            SceneManager.LoadScene(ScenesName);
        }
    }
}
