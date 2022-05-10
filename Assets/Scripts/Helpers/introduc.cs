using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introduc : MonoBehaviour
{
    public GameObject intros;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (intros.activeSelf)
        {
            Time.timeScale = 0f;
        }
        
    }
}
