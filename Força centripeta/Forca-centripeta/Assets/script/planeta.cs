﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeta : MonoBehaviour {
    public Transform pai;
    public int vely;
	// Use this for initialization
	void Start () {
        vely = 200;
    }
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(pai.position, transform.up, vely * Time.deltaTime);
	}
}
