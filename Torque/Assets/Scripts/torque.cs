using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torque : MonoBehaviour {


    public Transform prego;


    void Start ()
    {
        

    }

    void Update () {
        Vector3 a = new Vector3(-0.96f, 0, -7f);
        transform.RotateAround(prego.position, a , 600 * Time.deltaTime);
        
    }


void OnGUI()
{
 /*   GUI.contentColor = Color.black;
    GUI.Label(new Rect(20, 20, 100, 60), "Torque:");
    GUI.Label(new Rect(90, 20, 100, 30), (distancia*forca).ToString());


    GUI.Label(new Rect(20, 60, 60, 60), "Distância:");
    GUI.Label(new Rect(20, 100, 50, 60), "Força:");
    GUI.contentColor = Color.green;
    distancia2 = GUI.TextField(new Rect(90, 60, 50, 30), distancia2, 3);
    forca2 = GUI.TextField(new Rect(90, 100, 50, 30), forca2, 3);
    float.TryParse(forca2, out forca);
    float.TryParse(distancia2, out distancia);
*/
}


}
