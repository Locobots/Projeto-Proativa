using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveSquare : MonoBehaviour 
{
	float distance = 10;
	public float deformacao, consElastica, forcaElastica, energiaPotElastica;
	public string aux1,aux2,aux3;

	public SpringJoint2D mola; 

	public float frequency;

	void Start()
	{
		consElastica = 0.0f;
		energiaPotElastica = 0.0f;
		deformacao = 0.0f;
		forcaElastica = 0.0f;
	}

	void Update()
	{
		forcaElastica = consElastica * deformacao;
		energiaPotElastica = (consElastica * deformacao * deformacao) / 2;

		mola.frequency = 0.8f;
		mola.dampingRatio = (consElastica / 1000);

	}


	void OnMouseDrag()
	{
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
		transform.position = objPosition;
	}

	void OnGUI()
	{
		GUI.Label (new Rect (500, 50, 150, 50), forcaElastica.ToString () + " N");

		GUI.Label (new Rect (500, 110, 150, 50), energiaPotElastica.ToString () + " J");

		aux1 = GUI.TextField(new Rect(120, 40, 150, 50), aux1, 25);
		float.TryParse (aux1, out consElastica);

		aux2 = GUI.TextField(new Rect(220, 500, 150, 50), aux2, 25);
		float.TryParse (aux2, out deformacao);

	}




}
