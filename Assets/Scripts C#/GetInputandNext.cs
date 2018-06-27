using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInputandNext : MonoBehaviour
{
    public Slider slider;
    public Text rookvraag;

    void Start()
    {
        slider.minValue = 0;
        slider.value = 0;
        slider.wholeNumbers = true;
    }

    public void OnValueChange()
    {
        rookvraag.text = slider.value.ToString();
    }

}