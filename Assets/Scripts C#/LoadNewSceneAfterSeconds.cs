using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewSceneAfterSeconds : MonoBehaviour
{
    public static IEnumerator LoadLevelAfterDelay(float wachttijd)
    {
        yield return new WaitForSeconds(wachttijd);
        //Application.LoadLevel("FirstTimeStartup");
    }
}



