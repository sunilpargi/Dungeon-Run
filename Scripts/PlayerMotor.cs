using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = 12f;
    public float verticalVelocity = 0f;
    public float startTime;
    public Vector3 moveVector;
    public CharacterController characterController;
    private float animationDuration = 3f;

    public bool isDead;
    void Start()
    {
        startTime = Time.time;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;


        if(Time.time - startTime < animationDuration)
        {
            characterController.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (characterController.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;   
        }

        //x
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x > Screen.width / 2)
            {
                moveVector.x = speed;
            }
            else
            {
                moveVector.x = -speed;
            }
        }

        //y
        moveVector.y = verticalVelocity;

        //z
        moveVector.z = speed;
        moveVector.x = Mathf.Clamp(moveVector.x, -2.11f, 2.11f);

        characterController.Move(moveVector * Time.deltaTime);
    }

    public void SetSpeed(float modifier)
    {
        speed += modifier;
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //hit.point.z > transform.position.z + 0.1f &&
        if ( hit.gameObject.tag == "Enemy")
        {
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDead();
    }
}
