using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDrop : MonoBehaviour
{
    //Variables coger residuos
    public GameObject HandPoint;
    private GameObject picketObject = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        recoger();
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Orga"))
        {
            if (Input.GetKey("e") && picketObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = HandPoint.transform.position;
                other.gameObject.transform.SetParent(HandPoint.gameObject.transform);
                picketObject = other.gameObject;
            }
        }
        else if (other.gameObject.CompareTag("Aprov"))
        {
            if (Input.GetKey("e") && picketObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = HandPoint.transform.position;
                other.gameObject.transform.SetParent(HandPoint.gameObject.transform);
                picketObject = other.gameObject;
            }

        }
        else if (other.gameObject.CompareTag("NoAprov"))
        {
            if (Input.GetKey("e") && picketObject == null)
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

    }
}
