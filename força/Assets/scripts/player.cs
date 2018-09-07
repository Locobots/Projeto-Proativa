using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    bool grounded, aux = true; // variável para pular, variável para aplicar força apenas uma vez
    string ms, fs; // massa recebida do usuario, força recebida do usuário
    public float F, h , hl, m; // força, sentido da velocidade, sentido da força, massa
	
	public Rigidbody2D body; // corpo do verde
    public Rigidbody2D body2; // corpo do vermelho
    public GameObject floar; // rampa

    // Use this for initialization
    void Start () {
		body = GetComponent<Rigidbody2D> ();
		F = 0.0f; fs = "0";
        m = 1; ms = "1";


        grounded = true;
    }
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxis("Horizontal"); // direção para o personagem andar verde andar
        if (h < 0) { hl = -1;} // direção da força aplicada sobre o personagem vermelho
        else { hl = 1; }
        //---------------------------------------------------------------------------------------------------------------------------
        if (Input.GetKey(KeyCode.I)) { // mudando o angula da rampa 
        floar.transform.RotateAround(new Vector3(2.7f, -2.45f, 0), transform.eulerAngles, 3);
        floar.transform.position = new Vector3(floar.transform.position.x + 0.10f, floar.transform.position.y + 0.10f, floar.transform.position.z);
        }

        if (Input.GetKey(KeyCode.O))
        {
            aux = true;
            body.velocity = new Vector2(0, 0);
            body2.velocity = new Vector2(0, 0);
            body.position = new Vector2(-6.5f, -2);
            body2.position = new Vector2(-5.5f, -2);
            floar.transform.position = new Vector3(2.7f, -4.3f, 0);
            floar.transform.rotation = Quaternion.EulerRotation(0, 0, 0);
        }

        //---------------------------------------------------------------------------------------------------------------------------

        if (aux == true) { // sistema para andar
		body.velocity = new Vector2 (6 * h, body.velocity.y);
        }  

		if (Input.GetKey (KeyCode.Space) && grounded) { // sistema para pular
            body.AddForce(Vector2.up * 1000);
            grounded = false;
		}
        body2.mass = m; // modificando a massa
        
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Floor") // sistema para pular
		{
			grounded = true;
		}
        if(col.gameObject.name == "enemy") // sistema para aplicar força
        {
            aux = false;
            
            body.velocity = new Vector2(0, 0);
            body2.velocity = new Vector2(0, 0);
            body2.AddForce(new Vector2(1,0)*F*hl);
        }
	}
	void OnGUI() // GUI colocar texto na tela, e acrescentar valores
	{
		//Saída
		GUI.contentColor = Color.black;
        GUI.Label(new Rect(10, 10, 200, 60), "I --> Rampa");
        GUI.Label(new Rect(10, 30, 200, 60), "O --> Origem");
        GUI.Label(new Rect(10, 50, 200, 60), "Força aplicada: ");
		GUI.Label(new Rect(100, 50, 200, 30), F.ToString());

		// Entrada

		GUI.Label(new Rect(450, 10, 100, 30), "Alterar Força");
		GUI.contentColor = Color.white;
		fs = GUI.TextField(new Rect(545, 10, 100, 30), fs, 4);
		float.TryParse(fs, out F);

        GUI.contentColor = Color.black;
        GUI.Label(new Rect(450, 50, 100, 30), "Alterar Massa");
        GUI.contentColor = Color.white;
        ms = GUI.TextField(new Rect(545, 50, 100, 30), ms, 4);
        float.TryParse(ms, out m);



    }
}