using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public Transform per;
    public Transform cam;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.position = Vector3.Lerp(
            cam.position, new Vector3(per.position.x, cam.position.y, cam.position.z), 1f);
        
    }
}