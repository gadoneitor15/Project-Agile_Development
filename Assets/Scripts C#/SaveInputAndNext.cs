using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveInputAndNext : MonoBehaviour {

    public Slider slider;

    public void saveAndNext()
    {
        GameController.control.PlayerData.Cigarettes = (int)slider.value;
        GameController.control.PlayerData.saveData();
        Destroy(GameObject.Find("LogoPanel"));
        nextScene.switchScene("HomeMenu Scene");
    }
}
