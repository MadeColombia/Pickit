using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    Joystick joystick;

    [SerializeField]
    Transform Pointer;

    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pointer.position = new Vector3(joystick.Horizontal + transform.position.x, 28f, joystick.Vertical + transform.position.z);

        transform.LookAt(new Vector3(Pointer.position.x, 0, Pointer.position.z));

        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);

        if (joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {
           transform.Translate(Vector3.forward * 200f *Time.deltaTime);
            //controller.Move(Vector3.forward * 200f * Time.deltaTime);
        }
    }
}
