using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tap : MonoBehaviour
{
    private int Taps;
    public string ScenesName;
    // Start is called before the first frame update
    public void tapC ()
    {
        Taps = Taps + 1;
    }
    private void Update()
    {
        if (Taps == 12 )
        {
           SceneManager.LoadScene(ScenesName);        
        }
    }
}
