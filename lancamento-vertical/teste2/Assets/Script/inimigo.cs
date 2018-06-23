using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour {
    public float velo;
    int dir = 1;
    bool aux = false;
    public Rigidbody2D corpo;
	// Use this for initialization
	void Start () {
        corpo = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        corpo.velocity = new Vector2(velo * dir, corpo.velocity.y);

    }
        void OnCollisionEnter2D(Collision2D coll)
        { // acontece em toda colisão do meu corpo

            if (coll.gameObject.name == "parede" && aux == false)  { dir = -1; aux = true; }
            else if(coll.gameObject.name == "parede" && aux == true) { dir = 1;aux = false; }    
            else if(coll.gameObject.name == "personagem" && aux == true) { corpo.AddForce(Vector2.up * 2000); }
        }

   
}
