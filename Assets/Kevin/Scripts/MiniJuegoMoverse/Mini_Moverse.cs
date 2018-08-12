using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Moverse : MonoBehaviour {
    public Rigidbody miRigidBody;

    void Start () {
		
	}
	
	void Update () {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector2 direccion = new Vector2(horizontal, 0);

        direccion.Normalize();
        direccion.x *= 10;
        direccion.y = 0;
        miRigidBody.velocity = direccion;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cubo"))
        {
            Time.timeScale = 0;
            Debug.Log("Has perdido");
        }
    }
}
