using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateMedicineDrop : MonoBehaviour {

    [SerializeField]
    Dropdown DropMedicine;
    private void Start() {
        // load from playerprefs
        string pref = "MedicineDrop";
        string strMedicine = PlayerPrefs.GetString(pref, "");

        // convert to array, then to List
        if (strMedicine == "")
        {
            return;
        }
        string[] arrMedicine = strMedicine.Split(';');
        List<string> listMedicine = new List<string>(arrMedicine);

        // Make sure Add New is last item on the dropdown
        listMedicine.Add("Add New");

        DropMedicine.ClearOptions();
        DropMedicine.AddOptions(listMedicine);
    }

    private void OnApplicationPause(bool pause)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            SaveMedicineList();
        }
    }

    private void OnApplicationQuit()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            SaveMedicineList();
        }
    }

    private void SaveMedicineList () {
        // save to playerprefs
        string pref = "MedicineDrop";
        string newSave = "";

        List<Dropdown.OptionData> options = DropMedicine.options;
        int i = 1;
        if (options.Count > 1)
        {
            newSave += options[0].text;
        }
        while (i < options.Count - 1)
        {
            newSave += ";" + options[i].text;
            i++;
        }
        PlayerPrefs.SetString(pref, newSave);
        PlayerPrefs.Save();
    }
}
