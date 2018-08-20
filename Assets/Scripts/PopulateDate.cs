using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateDate : MonoBehaviour {

    public Text textField;
    public Dropdown dropMonth;
    public Dropdown dropDay;
    public Dropdown dropYear;
     
	void Awake () {

        int month;
        Int32.TryParse(CacheData.data.currentDate.Substring(0, 2), out month);
        int day;
        Int32.TryParse(CacheData.data.currentDate.Substring(2, 2), out day);
        int year;
        Int32.TryParse(CacheData.data.currentDate.Substring(4, 4), out year);

        SetFields(month, year);
        SetDate(month, day, year);

        Read();
	}

    private void SetDate(int month, int day, int year)
    {
        dropMonth.value = month - 1;
        dropDay.value = day - 1;
        dropYear.value = year - 2017;
    }

    public void SetFields(int month, int year)
    {
        SetDayField(month);
        SetYearField(year);
    }

    private void SetDayField(int month)
    {
        dropDay.ClearOptions();

        switch (month)
        {
            case 2:
                List<string> febOptions = new List<string>(28);
                for (int i = 1; i < 29; i++)
                {
                    febOptions.Add(i.ToString());
                }
                dropDay.AddOptions(febOptions);
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                List<string> lowOptions = new List<string>(30);
                for (int i = 1; i < 31; i++)
                {
                    lowOptions.Add(i.ToString());
                }
                dropDay.AddOptions(lowOptions);
                break;
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
            default:
                List<string> options = new List<string>(31);
                for (int i = 1; i < 32; i++)
                {
                    options.Add(i.ToString());
                }
                dropDay.AddOptions(options);
                break;
        }
    }

    private void SetYearField(int year)
    {
        dropYear.ClearOptions();

        List<string> yearOptions = new List<string>(year - 2016);
        for (int i = 2017; i <= year; i++)
        {
            yearOptions.Add(i.ToString());
        }
        dropYear.AddOptions(yearOptions);
    }

    public void ChangeMonth()
    {
        SetDayField(dropMonth.value + 1);
    }

    public void PreviousDate()
    {
        if (dropDay.value > 0)
        {
            dropDay.value--;
        } else
        {
            if (dropMonth.value > 0)
            {
                dropMonth.value--;
                dropDay.value = dropDay.options.Count - 1; // might run too quickly, can manually set highest date here if needed
            } else
            {
                if (dropYear.value > 0)
                {
                dropYear.value--;
                }
                dropMonth.value = 11;
                dropDay.value = dropDay.options.Count - 1; // might run too quickly, can manually set highest date here if needed
            }
        }
        Read();
    }

    public void Read()
    {
        int month = dropMonth.value + 1;
        int day = dropDay.value + 1;
        int year = dropYear.value + 2017;

        CacheData.data.currentDate = CacheData.FormatDateString(month, day, year);
        string toRead = CacheData.data.currentDate;

        textField.text = PlayerPrefs.GetString(toRead, "");
    }

    public void NextDate()
    {
        if (dropDay.value < dropDay.options.Count - 1)
        {
            dropDay.value++;
        }
        else
        {
            if (dropMonth.value < 11)
            {
                dropMonth.value++;
                dropDay.value = 0;
            }
            else
            {
                if (dropYear.value < dropYear.options.Count - 1)
                {
                    dropYear.value++;
                }
                dropMonth.value = 0;
                dropDay.value = 0;
            }
        }
        Read();
    }
}
