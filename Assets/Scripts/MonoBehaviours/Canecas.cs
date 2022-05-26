using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canecas : MonoBehaviour
{
    public GameObject ObjPuntos;
    public float puntosQueDa;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Orga")
        {
            ObjPuntos.GetComponent<Puntaje>().puntos += puntosQueDa;
            Destroy(other);
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
