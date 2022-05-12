using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    public float velMovimiento = 60f;
    public float velRotacion = 100f;
    private Animator animacion;
    public float x, y;

    public Rigidbody rb;

    public bool Soltar;
    public bool Tomar;
    public bool AvanzarSolo;
    public float velDropeoTaker = 10f;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        
        transform.Rotate(0, x * Time.deltaTime * velRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velMovimiento);
        
        animacion.SetFloat("velX", x);
        animacion.SetFloat("velY", y);



        if (!Soltar)
        {
            transform.Rotate(0, x * Time.deltaTime * velRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velMovimiento);
            velMovimiento = 60f;
            velRotacion = 100f;
        }

        if (!Tomar)
        {
            transform.Rotate(0, x * Time.deltaTime * velRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velMovimiento);
            velMovimiento = 60f;
            velRotacion = 100f;
        }
        
        if (AvanzarSolo)
        {
            rb.velocity = transform.forward * velDropeoTaker; 
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            animacion.SetTrigger("Tomar");
            Tomar = true;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            animacion.SetTrigger("Soltar");
            Soltar = true;
        }
    }

    public void DejarDeTomar()
    {
            Tomar = false;
    }

    public void DejarDeSoltar()
    {
            Soltar = false;
    }

    public void AvanzoSolo()
    {
            AvanzarSolo = true;
    }

    public void DejarDeAvanzar()
    {
            AvanzarSolo = false;
    }
}
