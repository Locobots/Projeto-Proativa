using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torque : MonoBehaviour {


    Transform prego;
    public float v = 600, distancia = 10, vm = 600;
    string distancia2;
    Rigidbody body;

    void Start ()
    {
        body = GetComponent<Rigidbody>();
        distancia2 = "2";
        vm = 600;

    }

    void Update () {

        Vector3 a = new Vector3(0.17f, -0.34f, -6.76f);
       body.transform.RotateAround(new Vector3(0.17f, -0.34f, -6.76f), a , v * Time.deltaTime);
        body.velocity = new Vector3(0, 0, v * 0.0006f);
        if (body.transform.position.z > -5.18f && v>0) { vm = -vm; }
        if (body.transform.position.z < -6.78f && v < 0) { vm = -vm; }
        v =  vm * 0.1f * distancia;
        

    }


void OnGUI()
{
    GUI.contentColor = Color.black;
  /*  GUI.Label(new Rect(20, 20, 100, 60), "Torque:");
    GUI.Label(new Rect(90, 20, 100, 30), (distancia*forca).ToString());
  */

    GUI.Label(new Rect(20, 500, 60, 60), "Distância:");

    GUI.contentColor = Color.green;
    distancia2 = GUI.TextField(new Rect(90, 500, 50, 30), distancia2, 2);
    float.TryParse(distancia2, out distancia);
    if (distancia > 10 || distancia < -10)
        {
            distancia2 = "10";
            float.TryParse(distancia2, out distancia);
        }

}


}
