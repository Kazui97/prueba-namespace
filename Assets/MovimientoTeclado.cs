using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTeclado : MonoBehaviour
{
    public float Velocidad;
    float mouseX;


     void Start()
     {
        Velocidad = Random.Range(4f, 9f);
     }

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X");


        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Velocidad / 20;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Velocidad / 20;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Velocidad / 20;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Velocidad / 20 ;

        }
       

        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }
}
