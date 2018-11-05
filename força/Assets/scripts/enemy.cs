using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public GameObject floar;
    public GameObject chao;
    public GameObject setanormal;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "rampa") // sistema para pular
        {
            setanormal.transform.rotation = Quaternion.EulerRotation(0, 0, floar.transform.rotation.z);
        }
        if (col.gameObject.name == "Floor") // sistema para pular
        {
            setanormal.transform.rotation = Quaternion.EulerRotation(0, 0, chao.transform.rotation.z);
        }
    }
}
