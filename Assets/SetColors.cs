using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetColors : MonoBehaviour {
    public Button button;
    public Text buttonText;
    public Slider sliderRed, sliderGreen, sliderBlue;
    public Slider sliderTextRed, sliderTextGreen, sliderTextBlue;

    public void setButtonColor()
    {
        float valRed = sliderRed.value;
        float valGreen = sliderGreen.value;
        float valBlue = sliderBlue.value;

        button.image.color = new Color(valRed, valGreen, valBlue);
    }

    public void setButtonTextColor(float valRed, float valGreen, float valBlue)
    {
        buttonText = button.GetComponentInChildren<Text>();
        buttonText.color = new Color(valRed, valGreen, valBlue);
    }
}
