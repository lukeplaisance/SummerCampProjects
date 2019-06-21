using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehaviour : MonoBehaviour
{
    [Range(-1, 1)] public int xRotate;
    [Range(-1, 1)] public int yRotate;
    [Range(-1, 1)] public int zRotate;

    public float RotateSpeed;
	
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(xRotate, yRotate, zRotate) * RotateSpeed);
	}
}
