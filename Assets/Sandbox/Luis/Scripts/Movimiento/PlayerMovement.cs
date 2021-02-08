using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // 3. Referencia a nuestro character controller
    public CharacterController controller;

    // 5. Hacer variable para velocidad de movimiento
    public float speed = 15f;

    // 6. Agregar variable para velocidad de grabedad
    Vector3 velocity;

    // 7. Agregar variable de gravedad
    public float gravity = -9.81f;

    // 10. Inicializar chequeo de suelo
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    bool isGrounded;

    // 13. Hacer variable para velocidad de salto
    public float jumpHeight = 3f;

    void Update()
    {
        // 11. Checar si esta tocando el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // 12. Resetear velocidad
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // 1. Agregar inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 2. Hacer los imputs direcciones, se usa transform para que el movimiento sea en base a donde ve el personaje
        Vector3 move = transform.right * x + transform.forward * z;

        // 4. Hacer que nuestro character controller se mueva
        controller.Move(move * speed * Time.deltaTime);

        // 14. Hacer equacion para salto
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // 8. Agregar la gravedad a la velocidad
        velocity.y += gravity * Time.deltaTime;

        // 9. Ejercer la velocidad de la grabedad sobre el personaje
        controller.Move(velocity * Time.deltaTime);

    }
}
