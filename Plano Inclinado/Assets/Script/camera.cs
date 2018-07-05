using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public Transform pt;
    public Transform ct;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ct.position = Vector3.Lerp(ct.position, new Vector3(pt.position.x, pt.position.y, ct.position.z), 1f);

	}
}
