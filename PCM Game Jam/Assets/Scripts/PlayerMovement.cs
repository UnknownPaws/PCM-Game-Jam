using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight;

    private bool isGrounded;
    private Vector3 velocity;

    // Update is called once per frame
    private void Update()
    {
        float actualSpeed = speed;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < -2)
        {
            velocity.y = -2f;
            actualSpeed = speed;
        }
        else
        {
            actualSpeed = speed/1.5f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * actualSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * -acceleration);
        }

        velocity.y += -acceleration * Time.deltaTime ; // 1/2 a t^2 = x   therefore we need time^2 and half of acceleration downwards

        controller.Move(velocity * Time.deltaTime);
    }
}
