using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class persof : MonoBehaviour
{

    //_____________________________________________________________________________________________________________________________________
    // Declarando variável

    public float velocidade, angulo; // entrada do usuário
    public string ve, an;
    public double posicao; // Delta posição
    public float t, altM; // variável tempo e altura maxima
    float a, sin, cos; // angulo em radiano, seno e cosseno do angulo
    int aux, aco = 0; // variável auxiliar (0) <Pode pular> (1) <esta no ar com velocidade x,y> (2) <esta no ar com velocidade x>
    bool al; // variável para pegar uma altura máxima
    public Vector2 position, velo; // posição (x,y) e velocidade do corpo
    Rigidbody2D body; // corpo do meu personagem
  

    //_____________________________________________________________________________________________________________________________________
    // Iniciar variável )(parâmetros iniciais)
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
        aux = 0;
        t = 0;
        velocidade = 5;
        ve = "5";
        angulo = 45;
       an = "45";
        al = true;
    }

    //_____________________________________________________________________________________________________________________________________
    // Loop infinito
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // pega a direção da minha seta horinzontamente 
        body.velocity = new Vector2(10 * h, body.velocity.y);
        position = body.transform.position;
        
        a = Mathf.PI * angulo / 180; // transformando o angulo em radiano
        sin = Mathf.Sin(a); // seno do angulo
        cos = Mathf.Cos(a);// cosseno do angulo
        velo.x = cos * velocidade;
        velo.y = sin * velocidade;

        // se meu espaço for clicado, e velocidade não for zero, e meu objeto estiver no chão então aux = 1;
        if (Input.GetKeyDown(KeyCode.Space) && velocidade != 0 && aux == 0) { aux = 1; aco = 0; } 
        // se minha tecla o for clicada a posição do meu objeto é (0,0,-2), o tempo zera, o delta x zera;
        if (Input.GetKeyDown(KeyCode.O)) { body.transform.position = new Vector3(0, 0, -2); posicao = 0; t = 0; }

        if (body.position.x > 34.15599) { body.position = new Vector3(0, body.position.y, -2); aco++; }
        else if(body.position.x < 0) { body.position = new Vector3(34156/1000, body.position.y, -2); aco--; }
    }
    //_____________________________________________________________________________________________________________________________________
    // Fixando apenas um pixel

    void FixedUpdate()
    {
        if (aux == 1)
        {
            body.velocity = velo;
            aux = 2;
            posicao = body.transform.position.x;
            altM = body.transform.position.y;
        }
        else if (aux == 2)
        {
            body.velocity = new Vector2(velo.x, body.velocity.y);
            t++;
            if (body.velocity.y < 0.1 && body.velocity.y > -0.1 && al == true) { altM = (body.transform.position.y - altM) * 104 / 100; al = false; }
        }
    }
    //_____________________________________________________________________________________________________________________________________
    // Se corpo colidir

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "chao")
        {
            aux = 0;
            posicao = body.transform.position.x - posicao + 34.15599 * aco;
            t = t / 60;
            al = true;
        }
    }

    void OnGUI() // GUI colocar texto na tela, e acrescentar valores
    {
        //Saída
        GUI.contentColor = Color.black; 
        GUI.Label(new Rect(10, 10, 200, 60), "TEMPO:");
        GUI.Label(new Rect(100, 10, 200, 30), t.ToString("0.00"));
        GUI.Label(new Rect(10, 30, 200, 60), "ALTURA-MAX");
        GUI.Label(new Rect(100, 30, 200, 30), altM.ToString("0.000"));
        GUI.Label(new Rect(10, 50, 200, 60), "DELTA-X");
        GUI.Label(new Rect(100, 50, 200, 30), posicao.ToString("0.000"));

        // Entrada
        
        GUI.Label(new Rect(220, 10, 100, 30), "VELOCIDADE: ");
        GUI.Label(new Rect(220, 50, 100, 30), "ÂNGULO: ");
        GUI.contentColor = Color.white;
        ve = GUI.TextField(new Rect(305, 10, 100, 30), ve, 3);
        an = GUI.TextField(new Rect(305, 50, 100, 30), an, 3);
        float.TryParse(ve, out velocidade);
        float.TryParse(an, out angulo);


    }
}
