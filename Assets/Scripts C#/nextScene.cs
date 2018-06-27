
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour {

    public static void switchScene(string letsGo)
    {
        SceneManager.LoadScene(letsGo);
    }

	public void naarVolgendeScene(string letsGo)
	{
		SceneManager.LoadScene(letsGo);
	}

	public void sluitApplicatie()
	{
		Application.Quit();
	}

    public void awardExp()
    {
        awardStuff.awardSExperience(100);
    }

	public static IEnumerator loadScene(float wachttijd, string level)
	{
		Debug.Log ("Waiting " + wachttijd + " seconds to switch to " + level);
		yield return new WaitForSeconds(wachttijd);
		SceneManager.LoadScene(level);
	}
}
