using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour {

    float altura, tempo;
    string text = "";
    bool j = true,h = false;
    Rigidbody2D body;
    public GameObject setapeso;
    public GameObject setanormal;
    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        altura = -3.714304f;
        tempo = 0;
        setanormal.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        setapeso.transform.position = new Vector3(body.transform.position.x + 0.07f, body.transform.position.y - 0.786554f, body.transform.position.z);
        setanormal.transform.position = new Vector3(body.transform.position.x + 0.07f, body.transform.position.y + 0.793446f, body.transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space) && !h && j){
            tempo = 0;
            j = false;
            Time.timeScale = 1;
            h = true;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            j = true;
            Time.timeScale = 1;
            setanormal.SetActive(false);
        }

     
    }

    void FixedUpdate()
    {
        if (h) { tempo++; }

        if (j)
        {
            body.transform.position = new Vector3(body.position.x, 4.73f - 1.08f * altura, -6);
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "floor")
        {
            h = false;
            tempo = tempo / 60;
            setanormal.SetActive(true);
        }
    }

    void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(10, 10, 200, 60), "TEMPO:");
        GUI.Label(new Rect(100, 10, 200, 30), tempo.ToString("0.00"));
        GUI.Label(new Rect(10, 30, 200, 60), "ALTURA");
        GUI.contentColor = Color.white;
        text = GUI.TextField(new Rect(100, 30, 100, 30), text, 4);
        float.TryParse(text, out altura);
        if (altura < 1 || altura > 9) { altura = 0; }
    }
}
