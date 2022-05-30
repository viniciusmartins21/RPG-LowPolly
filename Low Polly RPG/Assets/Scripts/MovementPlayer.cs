using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed;
    public float gravityForce = -9f;
    public float _gravity;
    Animator _anim;
    CharacterController controller;
    Vector3 moveDirection;
    

    void Start()
    {
        _anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }



    void Update()
    {
        //Inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");


        //movimento
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(horizontal, jump, vertical);
            //moveDirection = transform.TransformDirection(moveDirection);
            //moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
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
        controller.Move((moveDirection * speed * Time.deltaTime));


        //gravidade
        if (Input.GetKeyDown("Jump"))
        {
            moveDirection.y -= gravityForce * Time.deltaTime;
        }
        

        //if (controller.isGrounded && _gravity.y < 0) _gravity.y = 0;


        //_gravity.y += Time.deltaTime * gravityForce;


        //transform.Translate(moveDirection *  speed * Time.deltaTime);

    }
}
