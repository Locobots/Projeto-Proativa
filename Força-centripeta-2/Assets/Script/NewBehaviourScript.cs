using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    
    public float m, v;
    public string vs, ms;
    public bool aux;
    public Rigidbody2D body;
    public GameObject setapeso;
    public GameObject setanormal;
    public GameObject centro;
    private Vector3 a;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        m = 1;
        v = 10.0f;
        aux = true;
     }
    void Update()
    {
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.O))
        {
            body.transform.position = new Vector3(0.08f, -0.76f, 0);
            body.transform.rotation = Quaternion.EulerRotation(0, 0, 0);
            body.velocity = new Vector2(0, 0);
        }
        setanormal.transform.position = new Vector3(body.transform.position.x + 0.07f, body.transform.position.y - 2.4222f, body.transform.position.z);
        setapeso.transform.position = new Vector3(body.transform.position.x + 0.07f, body.transform.position.y - 2.4222f, body.transform.position.z);


        if (aux == true) {
            body.velocity = Vector2.Perpendicular(body.position) * v;
        }
        setanormal.transform.RotateAround(centro.transform.position, new Vector3(0,0,1), v * Time.deltaTime);
        body.AddForce(Vector2.down * m * 9.8f);
=======
       
        if (aux == true && v != 0) { body.velocity = Vector2.Perpendicular(body.position) * v; }
        body.mass = m;
>>>>>>> b4adf0b40cbf58fa15cb847041c828509353fed9
       
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


