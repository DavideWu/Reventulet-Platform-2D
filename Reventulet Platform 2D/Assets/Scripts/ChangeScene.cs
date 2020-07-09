using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int LvNeedToUnlock;
    public string ScenesName;
    private bool sceneUnlock = false;
    [Range (0.0f , 3.0f)]
    public float afterTime = 1.0f;
    private float timer = 0.0f;

    public void changeScene()
    {
        if(LvNeedToUnlock <= PlayerPrefs.GetInt("UnlockedLv"))
        {
            sceneUnlock = true;
        }
    }

    private void Update()
    {
        if(sceneUnlock)
        {
            timer += Time.deltaTime;
            if (timer > afterTime)
            {
                SceneManager.LoadScene(ScenesName);
            }
        }
    }
}
