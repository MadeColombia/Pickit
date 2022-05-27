using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canecas : MonoBehaviour
{
    public GameObject ObjPuntos;
    public float puntosQueDa;
    public GameObject Caneca;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other) {
        if(Caneca.tag == "verde")
        {
            if (other.tag == "Orga")
            {
                ObjPuntos.GetComponent<Puntaje>().puntos += puntosQueDa;
                Destroy(other);
                ObjPuntos.GetComponent<Puntaje>().correctos += 1;
            }
            else if (other.tag == "Aprov")
            {
                ObjPuntos.GetComponent<Puntaje>().puntos -= puntosQueDa;
                Destroy(other);
                ObjPuntos.GetComponent<Puntaje>().incorrectos += 1;
            }
            else if (other.tag == "NoAprov")
            {
                ObjPuntos.GetComponent<Puntaje>().puntos -= puntosQueDa;
                Destroy(other);
                ObjPuntos.GetComponent<Puntaje>().incorrectos += 1;
            }
        }
        else if(Caneca.tag == "blanco")
        {
            if (other.tag == "Orga")
            {
                ObjPuntos.GetComponent<Puntaje>().puntos -= puntosQueDa;
                Destroy(other);
                ObjPuntos.GetComponent<Puntaje>().incorrectos += 1;
            }
            else if (other.tag == "Aprov")
            {
                ObjPuntos.GetComponent<Puntaje>().puntos += puntosQueDa;
                Destroy(other);
                ObjPuntos.GetComponent<Puntaje>().correctos += 1;
            }
            else if (other.tag == "NoAprov")
            {
                ObjPuntos.GetComponent<Puntaje>().puntos -= puntosQueDa;
                Destroy(other);
                ObjPuntos.GetComponent<Puntaje>().incorrectos += 1;
            }


        }
        else if (Caneca.tag == "negro")
        {
            if (other.tag == "Orga")
            {
                ObjPuntos.GetComponent<Puntaje>().puntos -= puntosQueDa;
                Destroy(other);
                ObjPuntos.GetComponent<Puntaje>().incorrectos += 1;
            }
            else if (other.tag == "Aprov")
            {
                ObjPuntos.GetComponent<Puntaje>().puntos -= puntosQueDa;
                Destroy(other);
                ObjPuntos.GetComponent<Puntaje>().incorrectos += 1;
            }
            else if (other.tag == "NoAprov")
            {
                ObjPuntos.GetComponent<Puntaje>().puntos += puntosQueDa;
                Destroy(other);
                ObjPuntos.GetComponent<Puntaje>().correctos += 1;
            }


        }
       
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
