using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    Joystick joystick;

    [SerializeField]
    Transform Pointer;

    [SerializeField]
    CharacterController controller;

    public float x, z, y;
    Vector3 move;
    Vector3 movement;
    float velocity = 2f;
    [SerializeField]
    Animator animacion;

    [SerializeField]
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        x = joystick.Horizontal + Input.GetAxis("Horizontal");
        z = joystick.Vertical + Input.GetAxis("Vertical");

        Pointer.position = new Vector3(joystick.Horizontal + transform.position.x, 28f, joystick.Vertical + transform.position.z);

        transform.LookAt(new Vector3(Pointer.position.x, 0, Pointer.position.z));

        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);

        move = new Vector3(joystick.Horizontal + transform.position.z, 0, joystick.Vertical + transform.position.x);
        movement = transform.rotation * -move;

        if (joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {
            
            transform.Translate(Vector3.forward * 200f *Time.deltaTime);
            controller.Move(movement * 0.4f *Time.deltaTime);
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
}
