using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caixa : MonoBehaviour {

    public float speed;
    public Rigidbody2D body;
    string amb;
    float vx;


    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        if (body.position.x < -5.4 ) { 
        body.velocity = new Vector2(10 * h, body.velocity.y);
        }// cria aceleração
        if (Input.GetKeyDown(KeyCode.O)) {
            body.transform.position = new Vector3(-64/10, 7, 0);
        }
    }
    
        void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.name == "Fundo")
            {
            amb = "TERRA";
            }
        if (col.gameObject.name == "fundo de borracha")
        {
            amb = "BORRACHA";
        }
        if (col.gameObject.name == "Fundo gelo")
        {
            amb = "GELO";
        }

    }

    void OnGUI() // GUI colocar texto na tela, e acrescentar valores
    {
        //Saída
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(10, 10, 200, 60), "VELOCIDADE:");
        GUI.Label(new Rect(100, 10, 200, 30), body.velocity.x.ToString("0.00"));
        GUI.Label(new Rect(10, 30, 200, 60), "AMBIENTE:");
        GUI.Label(new Rect(100, 30, 200, 30), amb);
        
        /* Entrada
    GUI.Label(new Rect(220, 10, 100, 30), "VELOCIDADE: ");
    GUI.Label(new Rect(220, 50, 100, 30), "ÂNGULO: ");
    GUI.contentColor = Color.white;
    ve = GUI.TextField(new Rect(305, 10, 100, 30), ve, 3);
    an = GUI.TextField(new Rect(305, 50, 100, 30), an, 3);
    float.TryParse(ve, out velocidade);
    float.TryParse(an, out angulo);

    */
    }


}
