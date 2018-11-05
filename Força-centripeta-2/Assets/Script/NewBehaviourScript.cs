using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    
    public float m, v;
    public string vs, ms;
    public bool aux;
    public Rigidbody2D body;
    
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        m = 1;
        v = 10.0f;
        aux = true;
        ms = vs = "1";

     }
    void Update()
    {
       
        if (aux == true && v != 0) { body.velocity = Vector2.Perpendicular(body.position) * v; }

        body.AddForce(Vector2.down * m * 9.8f);
       
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "GameObject")
        {
            aux = true;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        aux = false;
    }

    void OnGUI() // GUI colocar texto na tela, e acrescentar valores
    {
        //Saída
        /*
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(50, 10, 200, 60), "W: ");
        GUI.Label(new Rect(100, 10, 200, 30), w.ToString());

        GUI.Label(new Rect(50, 30, 200, 60), "V_min");
        GUI.Label(new Rect(100, 30, 200, 30), vemin.ToString());

        GUI.Label(new Rect(50, 50, 200, 60), "F: ");
        GUI.Label(new Rect(100, 50, 200, 30), F.ToString());
        */
        // Entrada
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(50, 10, 100, 50), "Alterar velocidade: ");
        GUI.Label(new Rect(50, 50, 100, 30), "Alterar massa");
        GUI.contentColor = Color.white;
        vs = GUI.TextField(new Rect(200, 10, 100, 30), vs, 3);
        ms = GUI.TextField(new Rect(200, 50, 100, 30), ms, 3);
        float.TryParse(vs, out v);
        float.TryParse(ms, out m);

    }
}


