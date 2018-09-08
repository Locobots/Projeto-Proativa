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
    float a; // angulo em radiano, seno e cosseno do angulo
    int aux, aco = 0; // variável auxiliar (0) <Pode pular> (1) <esta no ar com velocidade x,y> (2) <esta no ar com velocidade x>
    bool al; // variável para pegar uma altura máxima
    public Vector2 position, velo; // posição (x,y) e velocidade do corpo
    public float ad;
    Rigidbody2D body; // corpo do meu personagem
    public GameObject seta, normal, peso;
  

    //_____________________________________________________________________________________________________________________________________
    // Iniciar variável )(parâmetros iniciais)
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        normal.SetActive(false);
        peso.SetActive(false);

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
        velo.x = Mathf.Cos(a) * velocidade;
        velo.y = Mathf.Sin(a) * velocidade;

        // se meu espaço for clicado, e velocidade não for zero, e o angulo não for apontando para baixo
        // e meu objeto estiver no chão então ele pode pula aux = 1;
        if (Input.GetKeyDown(KeyCode.Space) && velocidade != 0 && aux == 0 && angulo>=5 && angulo <=175) { aux = 1; aco = 0; } 

        // se minha tecla 'O' for clicada a posição do meu objeto é (0,0,-2), o tempo zera, o delta x zera;
        if (Input.GetKeyDown(KeyCode.O)) {
            body.transform.position = new Vector3(0, 0, -2);
            posicao = 0; t = 0; aco = 0;
            body.velocity = new Vector2(0, 0);
        }

        if (Input.GetKey(KeyCode.P)) // sistem de pausa
        {
            Time.timeScale = 0;
            if (aux == 0) { normal.SetActive(true); } // se chão tiver acionado tem normal
            peso.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1;
        }

        if (body.position.x > 34.15599) { body.position = new Vector3(0, body.position.y, -2); aco++; }
        else if(body.position.x < 0) { body.position = new Vector3(34.156f, body.position.y, -2); aco--; }
    }
    //_____________________________________________________________________________________________________________________________________
    // Fixando apenas um pixel

    void FixedUpdate()
    {
       ad = seta.transform.rotation.eulerAngles.z - 90; // ajuste do angulo com a seta
        if (ad < 0 && ad > -90) { ad = ad + 360; } // ajuste para não ter angulo negativo
        if (ad < angulo - 1 || ad > angulo + 1){  // pegando o com variação de +-1
        seta.transform.RotateAround(body.position, transform.eulerAngles, 1);
    }
        if (aux == 1) // quando o personagem pula
        {
            body.velocity = velo; // add velocidade
            aux = 2; // ir para a proxima etapa --> pegar o tempo e altura máxima
            posicao = body.transform.position.x; // pega a posição em quando ele pula
            altM = body.transform.position.y; // pega a posição em y quando ele pula
        }
        else if (aux == 2)
        {
            body.velocity = new Vector2(velo.x, body.velocity.y);// velocidade em x fica sempre add
            t++; // contando o tempo
            if (body.velocity.y < 0.1 && body.velocity.y > -0.1 && al == true) { // se a velocidade do corpo for quase zero
                altM = (body.transform.position.y - altM) * 1.04f; // adiciona 4% para compensar erro
                al = false;
            }
        }
        normal.SetActive(false);
        peso.SetActive(false);

    }
    //_____________________________________________________________________________________________________________________________________
    // Se corpo colidir

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "chao") // sistema para pular
        {
            aux = 0; // pode pular
            posicao = body.transform.position.x - posicao + 34.15599f * aco; // delta x
            t = t / 60; //
            al = true; // pode pegar altura máxima
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
        ve = GUI.TextField(new Rect(305, 10, 100, 30), ve, 4);
        an = GUI.TextField(new Rect(305, 50, 100, 30), an, 3);
        float.TryParse(ve, out velocidade);
        float.TryParse(an, out angulo);


    }
}
