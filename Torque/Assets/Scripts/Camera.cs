using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public GameObject jogador;

    private Vector3 offset;
	
	void Start () {
        offset = transform.position - jogador.transform.position;
    }
	
	// chamado a apos cada frame
	void LateUpdate () {
        transform.position = jogador.transform.position + offset;
	}
}
