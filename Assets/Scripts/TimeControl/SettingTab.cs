using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace TimeControl
{

    public class SettingTab : EditorWindow
    {

        [MenuItem("Time Setting / Time Controller")]
        public static GameObject CreateTimeController()
        {
            Debug.Log("create time controller");
            GameObject timeController = (GameObject)Resources.Load("TimeController");
            timeController = Instantiate(timeController);
            timeController.name = "TimeController";
            return timeController;
        }





        //[MenuItem("Time Setting / show test window")]
        //public static void ShowWindow()
        //{
        //    SettingTab t = (SettingTab)GetWindow(typeof(SettingTab));
        //    t.minSize = new Vector2 (300, 300);
        //    t.maxSize = new Vector2 (300, 300);

        //    // you can create more logic here

        //}

        

    }
}

    
