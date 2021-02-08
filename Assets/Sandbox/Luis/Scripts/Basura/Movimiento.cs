using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 2;
    Rigidbody rb;
    public float gravity = -9.81f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    bool isGrounded;

    public float jumpHeight = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(xMov, rb.velocity.y, yMov) * speed;
        Vector3 move = transform.right * xMov + transform.forward * yMov;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // 8. Agregar la gravedad a la velocidad
        velocity.y += gravity * Time.deltaTime;

       
        
    }
}
