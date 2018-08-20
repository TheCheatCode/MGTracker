using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacheData : MonoBehaviour {

    public static CacheData data;
    public Color buttonColor;
    public Color buttonFontColor;

    readonly System.DateTime now = System.DateTime.Now;
    public string currentDate = "";

    private void Awake()
    {
        if (data == null)
        {
            DontDestroyOnLoad(gameObject);
            data = this;
        } else if (data != this)
        {
            Destroy(gameObject);
        }

        if (data.currentDate == "")
        {
            data.currentDate = FormatDateString(now.Month, now.Day, now.Year);
        }
        // Set this before calling into the realtime database.
        // FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://mgtracker-e7706.firebaseio.com/");
        // FirebaseApp.DefaultInstance.SetEditorP12FileName("MGTracker-7f4ae9b5915b.p12");
        // FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("apptest@mgtracker-e7706.iam.gserviceaccount.com");
        // FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");

        // Get the root reference location of the database.
        // DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public static string FormatDateString(int month, int day, int year)
    {
        string result = "";
        if (month < 10) // guarantee two digit month
        {
            result += "0";
        }
        result += month.ToString();
        if (day < 10) // guarantee two digit day
        {
            result += "0";
        }
        result += day.ToString();
        result += year.ToString();

        return result;
    }

    public void ApplySettings()
    {
        GameObject[] Buttons = GameObject.FindGameObjectsWithTag("Button");
    }
}
