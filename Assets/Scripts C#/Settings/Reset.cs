using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject Canvas;

    public void selectYes()
    {
        GameController.control.resetGame();
        nextScene.switchScene("SettingsMain");
    }
    public void selectNo()
    {
        nextScene.switchScene("SettingsMain");
    }
}

