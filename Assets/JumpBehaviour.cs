using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour
{
    public float Jumpforce;
    public float DistanceToCollision;
    public bool IsGrounded;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Floor"))
        {
            IsGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IsGrounded = false;
    }

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            if(IsGrounded)
            {
                Debug.Log("Jump");
                GetComponent<Rigidbody>().AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
            }
        }
	}
}
