using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    public float puntos;
    public float correctos;
    public float incorrectos;
    public Text textP;
    public Text PuntosFinal;
    public Text IncorrectoFinal;
    public Text CorrectoFinal;

    // Update is called once per frame
    void Update()
    {
        textP.text = puntos.ToString();
    }

    public void finale()
    {
        /* PlayerPrefs.SetFloat("Puntos", puntos); */
        string nickname = PlayerPrefs.GetString("Nickname");
        int puntaje = (int)puntos;
        HighScores.UploadScore(nickname, puntaje);
        PuntosFinal.text = puntos.ToString();
        CorrectoFinal.text = correctos.ToString();
        IncorrectoFinal.text = incorrectos.ToString();

    }
}
