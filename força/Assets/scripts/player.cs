using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    bool grounded, aux = true; // variável para pular, variável para aplicar força apenas uma vez
    string ms, fs; // massa recebida do usuario, força recebida do usuário
    public float F, h , hl, m; // força, sentido da velocidade, sentido da força, massa
    int aux1, contador;
	
	public Rigidbody2D body; // corpo do verde
    public Rigidbody2D body2; // corpo do vermelho
    public GameObject floar; // rampa
    public GameObject setapeso;
    public GameObject setapeso2;
    public GameObject setaresultante;
    public GameObject setanormal;
    public GameObject chao;
    private bool ispause;

    // Use this for initialization
    void Start () {
        ispause = false;
        body = GetComponent<Rigidbody2D> ();
		F = 0.0f; fs = "0";
        m = 1; ms = "1";
        setaresultante.SetActive(false);
        contador = 0;
        grounded = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (body2.transform.position.x > -3.4f && body2.transform.position.x < -2.8f){
            Time.timeScale = 0;
            ispause = !ispause;
        }
        if (Input.GetKey(KeyCode.P))
        {
            if (ispause)
            {
                Time.timeScale = 1;
                ispause = !ispause;
                setaresultante.SetActive(false);
            }
        }
            setapeso.transform.position = new Vector3(body.transform.position.x + 0.016f, body.transform.position.y - 0.506f, body.transform.position.z);
        setapeso2.transform.position = new Vector3(body2.transform.position.x + 0.016f, body2.transform.position.y - 0.506f, body2.transform.position.z);
        setaresultante.transform.position = new Vector2(body2.position.x + 0.49f, body2.position.y + 0.037f);
        setanormal.transform.position = new Vector2(body2.position.x, body2.position.y + 0.463875f);
        //rotationnormal();

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
            setaresultante.SetActive(false);
            aux = true;
            body.velocity = new Vector2(0, 0);
            body2.velocity = new Vector2(0, 0);
            body.position = new Vector2(-6.5f, -2);
            body2.position = new Vector2(-5.5f, -2);
            floar.transform.position = new Vector3(2.7f, -4.3f, 0);
            floar.transform.rotation = Quaternion.EulerRotation(0, 0, 0);
            body2.transform.rotation = Quaternion.EulerRotation(0, 0, 0);
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
    void rotationnormal()
    {
        aux1 = contador * 360;
        if (body2.transform.rotation.z >= (360 + aux1))
        {
            contador++;
            aux1 = contador * 360;
        }
        
        if (body2.transform.rotation.z < (90 + aux1))
            setanormal.transform.rotation = Quaternion.EulerRotation(0, 0, body2.transform.rotation.z);
        else if (body2.transform.rotation.z < (180 + aux1))
            setanormal.transform.rotation = Quaternion.EulerRotation(0, 0, body2.transform.rotation.z - 90);
        else if (body2.transform.rotation.z < (270 + aux1))
            setanormal.transform.rotation = Quaternion.EulerRotation(0, 0, body2.transform.rotation.z - 180);
        else if (body2.transform.rotation.z < (360 + aux1))
            setanormal.transform.rotation = Quaternion.EulerRotation(0, 0, body2.transform.rotation.z - 270);

       
    }

	void OnCollisionEnter2D(Collision2D col)
	{
        if (col.gameObject.name == "rampa") // sistema para pular
        {
            setanormal.transform.rotation = Quaternion.EulerRotation(0, 0, floar.transform.rotation.z);
        }
        if (col.gameObject.name == "Floor") // sistema para pular
		{
			grounded = true;
            setanormal.transform.rotation = Quaternion.EulerRotation(0, 0, chao.transform.rotation.z);
        }
        if(col.gameObject.name == "enemy") // sistema para aplicar força
        {
            aux = false;
            
            body.velocity = new Vector2(0, 0);
            body2.velocity = new Vector2(0, 0);
<<<<<<< HEAD
            body2.AddForce(new Vector2(1,0)*F*hl);
            setaresultante.transform.localScale = new Vector2(F / (5000*m), F / (5000*m));
            setaresultante.SetActive(true);

=======
            body2.AddForce(new Vector2(1,0)*F*10*hl);
>>>>>>> b4adf0b40cbf58fa15cb847041c828509353fed9
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