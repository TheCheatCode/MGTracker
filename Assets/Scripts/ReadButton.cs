using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReadButton : MonoBehaviour {

    public Text textField;

    public void ReadExternal()
    {
        string path = Application.persistentDataPath + "/" + CacheData.data.currentDate + ".txt";

        StreamReader reader;
        try
        {
            if (File.Exists(path))
            {
                reader = new StreamReader(path);
                textField.text = reader.ReadToEnd();
                reader.Close();
            } else
            {
                Debug.Log("File not found");
            }
        }
        catch (IOException e)
        {
            Debug.Log(e.Message);
        }
    }
}
