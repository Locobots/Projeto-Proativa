using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torque : MonoBehaviour {

    public float distancia, forca;
    public string distancia2, forca2;

    public float cima, giro;

    void Start ()
    {
        distancia = forca = 0.0f;
        distancia2 = "0";
        forca2 = "0";

    }

    void Update () {
    if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.RightArrow)))
        transform.Translate(Vector3.up * ((distancia*forca)/400) * Time.deltaTime);

    if ((Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.LeftArrow)) )
        transform.Translate(-Vector3.up * ((distancia * forca) / 400) * Time.deltaTime);

    if ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.DownArrow)))
        transform.Rotate(Vector3.up, -(distancia*forca) * Time.deltaTime);

    if ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.UpArrow)))
        transform.Rotate(Vector3.up, (distancia * forca) * Time.deltaTime);
	}


void OnGUI()
{
    GUI.contentColor = Color.black;
    GUI.Label(new Rect(20, 20, 100, 60), "Torque:");
    GUI.Label(new Rect(90, 20, 100, 30), (distancia*forca).ToString());


    GUI.Label(new Rect(20, 60, 60, 60), "Distância:");
    GUI.Label(new Rect(20, 100, 50, 60), "Força:");
    GUI.contentColor = Color.green;
    distancia2 = GUI.TextField(new Rect(90, 60, 50, 30), distancia2, 3);
    forca2 = GUI.TextField(new Rect(90, 100, 50, 30), forca2, 3);
    float.TryParse(forca2, out forca);
    float.TryParse(distancia2, out distancia);
}


}
