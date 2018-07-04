using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour {

    public Text CronometroText;
    private float tempoAtual;

    // Use this for initialization
    void Start () {
        tempoAtual = 0;

    }
	
	// Update is called once per frame
	void Update () {
        tempoAtual += Time.deltaTime;
        CronometroText.text = tempoAtual.ToString("F2");
    }
}
