using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mao : MonoBehaviour {
    public GameObject mao1, mao2;
    public bool a, b, c;
    public new Vector3 ja;
    // Use this for initialization
	void Start () {
        b = false;
        a = true;
        c = true;
        mao1.SetActive(a);
        mao2.SetActive(b);
        
	}
	
	// Update is called once per frame
	void Update () {
        ja = Input.mousePosition;

        mao2.transform.position = new Vector3(ja.x -400, ja.y - 400, ja.z - 100)/100;
        mao1.transform.position = new Vector3(ja.x - 400, ja.y - 400, ja.z - 100)/100;

        mao1.SetActive(a);
        mao2.SetActive(b);

        if (Input.GetKeyDown(KeyCode.Space)) {
            a = !a;
            b = !b;
            
        }

        if (Input.GetMouseButton(0) && c)
        {
            a = !a;
            b = !b;
            c = false;
        }else if (Input.GetMouseButton(0) == false && c == false) { c = true; }


	}
}
