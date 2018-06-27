using UnityEngine;

public class ResetPopup : MonoBehaviour
{

    public Reset resetScript;

    public void showPopup()
    {
        resetScript.Canvas.SetActive(true);
    }
}
