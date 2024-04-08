using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float JumpHeight = 3f;

    public bool isGrounded;
    public bool canControl = true;

    Vector3 velocity;

    private void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (canControl)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded && canControl) 
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
