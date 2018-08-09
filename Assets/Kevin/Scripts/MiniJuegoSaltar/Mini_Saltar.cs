using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Saltar : MonoBehaviour
{
    public Rigidbody myRigidbody;
    Vector3 aire = new Vector3(0f, 0f, 0f);

    public void Saltar()
    {
        if (Input.GetButtonDown("Jump") && myRigidbody.transform.position == aire)
        {
            myRigidbody.AddForce(Vector3.up * 7, ForceMode.Impulse);
        }
    }

    

    void Start()
    {
    }

    void Update()
    {
        Saltar();
        
    }
}
