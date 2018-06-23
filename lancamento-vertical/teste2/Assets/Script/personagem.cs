using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personagem : MonoBehaviour {

    public float velo, velojum, j;
    public bool jump = true, chao = false;
    public persof v;

    public Rigidbody2D body; // rigidez do corpo
    

	// Use this for initialization
void Start () {
       
        body = GetComponent<Rigidbody2D>(); // a variável body pega o rigbody para poder fazer modificações
	}

    // Update is called once per frame
 void Update () {
        float h = Input.GetAxis("Horizontal"); // direção do objeto horizontalmente
        body.velocity = new Vector2(velo * h , body.velocity.y); // add um velocidade ao corpo do objeto
        //body.AddForce(Vector2.right * h * velo); // add um força ao objeto

        if (Input.GetKeyDown(KeyCode.UpArrow) && chao == true){jump = true; chao = false;  } 
        if (Input.GetKeyDown(KeyCode.Space)) { body.AddForce(Vector2.up * velojum); }
        // se meu usuário inserir a seta para cima então meu pulo é verdadeiro e meu chão é falso
    }

    void FixedUpdate() { // apenas um único frame
        if (jump == true) {body.AddForce(Vector2.up * velojum); jump = false;}
    }
    void OnCollisionEnter2D (Collision2D coll){ // acontece em toda colisão do meu corpo

            if (coll.gameObject.name == "chão") { chao = true; Debug.Log(body.transform.position.x); } // se o objeto que colidir tiver o nome chão então meu chão é true
        else { Debug.Log("Não estamos no chão"); }
     }
}
