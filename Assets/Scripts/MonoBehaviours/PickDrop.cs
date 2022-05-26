using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickDrop : MonoBehaviour
{
     

    //Variables coger residuos
    public GameObject HandPoint;
    private GameObject picketObject = null;

    [SerializeField]
    Animator animacion;

    [SerializeField]
    CharacterController controller;


    Vector3 move;
    public Button joystickButtonD;
    public Button joystickButtonT;
    public float velMovimiento = 120f;
    public float x, z, y;
    public Transform player;
    public bool Soltar;
    public bool Tomar;
    private bool isPressedPick;
    private bool isPressedDrop;
    // Start is called before the first frame update
    void Start()
    {
        isPressedDrop = false;
        isPressedPick = false;
    }

    // Update is called once per frame
    void Update()
    {
        soltar();
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Orga"))
        {
            if (isPressedPick != false && picketObject == null)
            {
                Take();
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = HandPoint.transform.position;
                other.gameObject.transform.SetParent(HandPoint.gameObject.transform);
                picketObject = other.gameObject;
                isPressedPick = false;
            }
        }
        else if (other.gameObject.CompareTag("Aprov"))
        {
            if (isPressedPick != false && picketObject == null)
            {
                Take();
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = HandPoint.transform.position;
                other.gameObject.transform.SetParent(HandPoint.gameObject.transform);
                picketObject = other.gameObject;
                isPressedPick = false;
            }

        }
        else if (other.gameObject.CompareTag("NoAprov"))
        {
            if (isPressedPick != false && picketObject == null)
            {
                Take();
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = HandPoint.transform.position;
                other.gameObject.transform.SetParent(HandPoint.gameObject.transform);
                picketObject = other.gameObject;
                isPressedPick = false;
            }

        }


    }

    public void soltar()
    {
        if (picketObject != null)
        {
            if (isPressedDrop != false)
            {
                Drop();
                picketObject.GetComponent<Rigidbody>().useGravity = true;
                picketObject.GetComponent<Rigidbody>().isKinematic = false;
                picketObject.gameObject.transform.SetParent(null);
                picketObject = null;
                isPressedDrop = false;
            }
        }

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

    public void CheckPick()
    {
        isPressedPick = true;
        //Debug.Log("Pick fue presionado");
    }
    public void CheckDrop()
    {
        isPressedDrop = true;
        //Debug.Log("Drop fue presionado");
    }
}
