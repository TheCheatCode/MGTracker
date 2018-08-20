using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class SubmitLine : MonoBehaviour {

    public InputField TimeHour;
    public InputField TimeMinute;
    public InputField inputBox;
    public Dropdown timeOfDay;
    public Dropdown DropFood;
    public Dropdown DropMedicine;

    public void SubmitCurrent()
    {
        string date = CacheData.data.currentDate;
        string newSave = inputBox.text;
        PlayerPrefs.SetString(date, newSave);
        PlayerPrefs.Save();
    }

    public void AddTime()
    {
        string currentText = inputBox.text;
        string toAdd = TimeHour.text + ":" + TimeMinute.text + timeOfDay.captionText.text + ": ";
        string currentLine = currentText;

        if (currentText.Contains(System.Environment.NewLine))
        {
            currentLine = currentText.Substring(currentText.LastIndexOf(System.Environment.NewLine) + 2);
        }

        if (currentLine.Length < 3)
        {
            inputBox.text += toAdd;
        }
        else
        {
            inputBox.text += System.Environment.NewLine + toAdd;
        }
    }

    public void AddOne()
    {
        string currentText = inputBox.text;
        string toAdd = DropMedicine.options[DropMedicine.value].text;
        string currentLine = currentText;

        if (currentText.Contains(System.Environment.NewLine)) {
            currentLine = currentText.Substring(currentText.LastIndexOf(System.Environment.NewLine) + 2);
        }
        //Debug.Log(currentLine.Length);
        if (currentLine.Length > 9)
        {
            inputBox.text += ", " + toAdd;
        }
        else
        {
            inputBox.text += toAdd;
        }
    }

    public void WriteExternal()
    {
        string path = Application.persistentDataPath + "/" + CacheData.data.currentDate + ".txt";

        try
        {
            StreamWriter writer;
            if(!File.Exists(path))
            {
                writer = File.CreateText(path);
                writer.Write(inputBox.text);
            } else
            {
                writer = new StreamWriter(path);
                writer.Write(inputBox.text);
            }
            writer.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            throw;
        }
    }
}
