using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    public float puntos;
    public Text textP;

    // Update is called once per frame
    void Update()
    {
        textP.text = puntos.ToString();
    }
}
