using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float movementSpeed = 12f;
    public float jumpForce = 15f;

    public float gravity = 30f;

    private Vector3 gravityVector;
    private Vector3 move;

    private void Update()
    {
        //Save & Load
        if (Input.GetButtonDown(""))

        //Player Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (controller.isGrounded) //Player cannot alter movement velocity mid-air.
        {
            if (z < 0)
            {
                move = transform.right * x * 0.75f + transform.forward * z * 0.5f;
            }
            else
            {
                move = transform.right * x * 0.75f + transform.forward * z;
            }            
        }
        controller.Move(move * movementSpeed * Time.deltaTime);

        //Gravity
        if (!controller.isGrounded)
        {
            gravityVector.y -= gravity * Time.deltaTime;
            controller.Move(gravityVector * Time.deltaTime);
        }
        else
        {
            gravityVector.y = -2f;
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            gravityVector.y = jumpForce;
            controller.Move(gravityVector * Time.deltaTime);
        }        
    }
}