using System;
using UnityEngine;
using UnityEngine.UI;

public class Initialize : MonoBehaviour {

    public InputField inputBlock;
    public InputField minutesField;
    public InputField hoursField;
    public Dropdown timeOfDay;

	// Use this for initialization
	void Awake () {
        SetTime();
        Read();
	}

    private void SetTime()
    {
        System.DateTime now = System.DateTime.Now;
        minutesField.text = now.Minute.ToString();
        ClampMinute(minutesField);
        int hours = now.Hour;
        if (hours > 12)
        {
            hours -= 12;
            timeOfDay.value = 1;
        }
        if (hours == 12)
        {
            timeOfDay.value = 1;
        }
        if (hours == 0)
        {
            hours = 12;
        }
        hoursField.text = hours.ToString();
    }

    public void Read()
    {
        string toRead = CacheData.data.currentDate;

        inputBlock.text = PlayerPrefs.GetString(toRead, "");
    }

    public void ClampHour(InputField toClamp)
    {
        int value;
        string stringValue = "";

        if (int.TryParse(toClamp.text, out value))
        {
            value = (int)Mathf.Clamp(value, 1f, 12f);
            stringValue += value.ToString();
            toClamp.text = stringValue;
        }
        else
        {
            toClamp.text = "12";
        }
    }

    public void ClampMinute(InputField toClamp)
    {
        int value;
        string stringValue = "";

        if (int.TryParse(toClamp.text, out value))
        {
            value = (int)Mathf.Clamp(value, 0f, 59f);
            if (value < 10)
            {
                stringValue += "0";
            }
            stringValue += value.ToString();
            toClamp.text = stringValue;
        }
        else
        {
            toClamp.text = "00";
        }
    }
}
