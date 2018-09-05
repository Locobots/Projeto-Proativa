using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Velo : MonoBehaviour{
    public GameObject Player;
    public Text VelocimetroText;
    private float velocidadeAtual;

    // Use this for initialization
    void Start()
    {
        velocidadeAtual = 0;
        GUI.Label(new Rect(100, 50, 200, 30), "TEMPO");
    }

    // Update is called once per frame
    void Update()
    {
        //velocidadeAtual = body.velocity.magnitude;
        VelocimetroText.text = velocidadeAtual.ToString("F2");
    }
}
