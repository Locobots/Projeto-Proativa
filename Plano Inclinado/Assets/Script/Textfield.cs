using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textfield : MonoBehaviour {

    public string name = " text field";
    public string textAreadString = "text area";
    // Use this for initialization
    void OnGUI()
    {
        name = GUI.TextField(new Rect(10, 10, 200, 20), name, 30);
        //textFieldString = GUI.TextArea(new Rect(700, 25, 100, 100), textFielddString, 250);
        //GUI.Label(new Rect(505, 75, 100, 100), textFieldString);
    }

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
