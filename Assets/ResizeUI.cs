using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeUI : MonoBehaviour {

    // Example Code

    //    
    // Rect screen = new Rect(0, 0, Screen.width, Screen.height);
    // if (GUI.Button(screen.Upper(.1f), "This button appears in the top 10% of the screen")) {//do stuff/
    // }
    // Rect brush = screen.Bottom(.333f);
    // GUI.Box(brush, "Group");
    // GUI.Box(brush.Left(.333f).Trim(8), "This appears in the bottom-left ninth of the screen,\n trimmed a little to fit inside it's parent");
    // GUI.Box(screen.MiddleCenter(.333f, .333f), "This appears in the middle-center ninth of the screen");
    //


    private void OnRectTransformDimensionsChange()
    {
        //GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Button");
        //foreach (GameObject button in allObjects)
        //{
            if (!(transform.localScale == new Vector3(0.3F, 0.07F)))
            {
                transform.localScale = new Vector3(0.3F, 0.07F);
            }
        //}
    }

}
