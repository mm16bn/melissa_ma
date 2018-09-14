using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Rotate : MonoBehaviour {

    public float RotateSpeed = 30f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
    }
}
