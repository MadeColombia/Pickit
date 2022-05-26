using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidController : MonoBehaviour
{

    [SerializeField]
    Joystick joystick;

    [SerializeField]
    Transform Pointer;

    [SerializeField]
    CharacterController controller;

    
    Vector3 move;
    Vector3 movement;
    float velocity = 2f;
    [SerializeField]
    Animator animacion;

    [SerializeField]
    Rigidbody rb;

    public Joystick joystickMove;
    public Button joystickButtonD;
    public Button joystickButtonT;
    public float velMovimiento = 120f;
    public float velRotacion = 200f;
    public float x, z, y; 
    private Vector3 forceDirection = Vector3.zero;
    public Transform player;
    

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
        x = joystick.Horizontal + Input.GetAxis("Horizontal");
        z = joystick.Vertical + Input.GetAxis("Vertical");

        Pointer.position = new Vector3(joystick.Horizontal + transform.position.x, 28f, joystick.Vertical + transform.position.z);

        transform.LookAt(new Vector3(Pointer.position.x, 0, Pointer.position.z));

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        move = new Vector3(joystick.Horizontal + transform.position.z, 0, joystick.Vertical + transform.position.x);
        movement = transform.rotation * -move;

        if (joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {

            transform.Translate(Vector3.forward * 200f * Time.deltaTime);
            controller.Move(movement * 0.4f * Time.deltaTime);
            animacion.SetFloat("velX", x);
            animacion.SetFloat("velY", Mathf.Abs(z));
            rb.velocity = transform.forward * 10f;


        }
        else
        {
            animacion.SetFloat("velX", 0);
            animacion.SetFloat("velY", 0);
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

    /*public void Drop()
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
    }*/

    // Update is called once per frame
    void Update()
    {
        Move();
        

    }

    /*private void OnTriggerStay(Collider other)
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
    }

    public void recoger()
    {
        if (picketObject != null)
        {
            if (Input.GetKey("r"))
            {
                picketObject.GetComponent<Rigidbody>().useGravity = true;
                picketObject.GetComponent<Rigidbody>().isKinematic = false;
                picketObject.gameObject.transform.SetParent(null);
                picketObject = null;
            }
        }

    }*/
}
