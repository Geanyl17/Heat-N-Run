using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false; 

    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

       animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

       if (Input.GetButtonDown("Jump"))
       {
            jump = true;
       }
    } 

    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}

