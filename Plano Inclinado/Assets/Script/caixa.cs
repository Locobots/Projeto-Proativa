using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caixa : MonoBehaviour {

    public float speed;
    //public float jumpspeed;
    //public bool jump = true;
    public Rigidbody2D body;
    //private bool grounded;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");

       //body.velocity = new Vector2(speed * h, body.velocity.y);
        body.AddForce(Vector2.right * h * speed);                          // cria aceleração

       /* if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            jump = true;
            grounded = false;
        }*/
    }
    /*private void FixedUpdate()
    {
        if (jump)
        {
            body.AddForce(Vector2.up * jumpspeed);
            jump = false;
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.name == "Floor inclinado")
            {
                grounded = true;
                Debug.Log("Tamos no chao");
            }
        }


    }*/
}
