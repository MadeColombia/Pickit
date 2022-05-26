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
    private Vector3 forceDirection = Vector3.zero;

    public Rigidbody rb;

    public Transform player;
    public CharacterController controller;

    public bool Soltar;
    public bool Tomar;
    public bool AvanzarSolo;
    public float velDropeoTaker = 10f;

    //Variables coger residuos
    public GameObject HandPoint;
    private GameObject picketObject = null;

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

        transform.Rotate(0, x * Time.deltaTime * velRotacion, 0); //Rotacion con joystick esto es lo que estorba
        transform.Translate(0, 0, z * Time.deltaTime * velMovimiento);
        
        animacion.SetFloat("velX", x);
        animacion.SetFloat("velY", z);

        //Otros parametros
        if (AvanzarSolo)
        {
            rb.velocity = transform.forward * velDropeoTaker; 
        }
    }

    /*private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if(move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }            
        
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }*/

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

    public void Drop()
    {
        //transform.Rotate(0, x * Time.deltaTime * velRotacion, 0);
        //transform.Translate(0, 0, y * Time.deltaTime * velMovimiento);
        //velMovimiento = 120f;
        //velRotacion = 200f;
        move = player.right * x + player.forward * z;
        controller.Move(move * velMovimiento * Time.deltaTime);
        animacion.SetTrigger("Tomar");
        Tomar = true;
    }

    public void Take()
    {
        //transform.Rotate(0, x * Time.deltaTime * velRotacion, 0);
        //transform.Translate(0, 0, y * Time.deltaTime * velMovimiento);
        //velMovimiento = 120f;
        //velRotacion = 200f;
        move = player.right * x + player.forward * z;
        controller.Move(move * velMovimiento * Time.deltaTime);
        animacion.SetTrigger("Soltar");
        Soltar = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //LookAt();
    }

    /* private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Orga"))
        {
            if(Input.GetKey("e") && picketObject==null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = HandPoint.transform.position;
                other.gameObject.transform.SetParent(HandPoint.gameObject.transform);
                picketObject = other.gameObject;
            }
        }
    } */
}
