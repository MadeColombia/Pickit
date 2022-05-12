using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidController : MonoBehaviour
{
    public Joystick joystickMove;
    public GameObject joystickButtonD;
    public GameObject joystickButtonT;

    public float velMovimiento = 120f;
    public float velRotacion = 200f;
    private Animator animacion;
    public float x, z, y;
    Vector3 move;

    public Rigidbody rb;

    public Transform player;
    public CharacterController controller;

    public bool Soltar;
    public bool Tomar;
    public bool AvanzarSolo;
    public float velDropeoTaker = 10f;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    void Move()
    {
        //Movimiento del personaje
        x = joystickMove.Horizontal + Input.GetAxis("Horizontal");
        z = joystickMove.Vertical + Input.GetAxis("Vertical");
        move = player.right * x + player.forward * z;
        controller.Move(move * velMovimiento * Time.deltaTime);

        transform.Rotate(0, x * Time.deltaTime * velRotacion, 0);
        transform.Translate(0, 0, z * Time.deltaTime * velMovimiento);
        
        animacion.SetFloat("velX", x);
        animacion.SetFloat("velY", z);

        //Otros parametros
        if (AvanzarSolo)
        {
            rb.velocity = transform.forward * velDropeoTaker; 
        }
    }

    void Drop()
    {
        //Esta afectando directamente al jugador requiere analisis
        //Boton de tomar
        if (!Tomar)
        {
            transform.Rotate(0, x * Time.deltaTime * velRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velMovimiento);
            velMovimiento = 120f;
            velRotacion = 200f;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            animacion.SetTrigger("Tomar");
            Tomar = true;
        }

        //Otros parametros
        if (AvanzarSolo)
        {
            rb.velocity = transform.forward * velDropeoTaker; 
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

    /*public void TomarResiduo()
    {
        //Boton de tomar
        if (!Tomar)
        {
            transform.Rotate(0, x * Time.deltaTime * velRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velMovimiento);
            velMovimiento = 60f;
            velRotacion = 100f;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            animacion.SetTrigger("Tomar");
            Tomar = true;
        }
    }*/

    void Take()
    {
        /*Soltar = Input.GetButtonDown("ButtonD");
        //Boton de tirar
        if (!Soltar)
        {
            transform.Rotate(0, x * Time.deltaTime * velRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velMovimiento);
            velMovimiento = 60f;
            velRotacion = 100f;
        }*/

        if(Input.GetButtonDown("ButtonD"))
        {
            transform.Rotate(0, x * Time.deltaTime * velRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velMovimiento);
            velMovimiento = 120f;
            velRotacion = 200f;
            move = player.right * x + player.forward * z;
            controller.Move(move * velMovimiento * Time.deltaTime);
            animacion.SetTrigger("Soltar");
            Soltar = true;
            Debug.Log("ButtonD");
        }

        /*if(Input.GetKeyDown(KeyCode.E))
        {
            animacion.SetTrigger("Soltar");
            Soltar = true;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Drop();
    }
}
