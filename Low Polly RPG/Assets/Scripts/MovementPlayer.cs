using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed;
    //public float gravityForce = -9f;
    public float _gravity,
        jumpForce,
        fallVelocity;
    Animator _anim;
    CharacterController controller;
    Vector3 moveDirection, yVelocity;
    
    

    void Start()
    {
        _anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

    }



    void Update()
    {

        Move();

        //setGravity();

        //Jump();

    }

    public void Move ()
    {
        //movimento
        if (controller.isGrounded)
        {
            //Inputs
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            bool jump = Input.GetButtonDown("Jump");


            moveDirection = new Vector3(horizontal, 0, vertical);
            moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
            controller.Move(moveDirection * speed * Time.deltaTime);


        }


        if (moveDirection != Vector3.zero)
        {
            _anim.SetBool("isMoving", true);
        }
        else
        {
            _anim.SetBool("isMoving", false);
        }

    }

    

    


    //Função usada para trabalhar com a fisica, roda a cada 0.2 segundos
    void FixedUpdate()
    {
        
            if (controller.isGrounded)
            {
                fallVelocity = -_gravity * Time.deltaTime;
                moveDirection.y = fallVelocity;
            }
            else
            {
                fallVelocity -= _gravity * Time.deltaTime;
                moveDirection.y = fallVelocity;
            }

        

            if (controller.isGrounded && Input.GetButtonDown("Jump"))
            {
                fallVelocity = jumpForce;
                moveDirection.y = fallVelocity;
            }
        

        /*
        if (controller.isGrounded)
        {
            fallVelocity = -_gravity * Time.deltaTime;
            moveDirection.y = fallVelocity;
        }
        else
        {
            fallVelocity -= _gravity * Time.deltaTime;
            moveDirection.y = fallVelocity;
        }
        */





    }
}
