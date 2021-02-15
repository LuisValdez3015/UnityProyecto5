using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 2. Agregar sensibilidad a movimiento de camara
    public float mouseSensitivityX = 100f;
    public float mouseSensitivityY = 100f;

    // 3. Hacer refrencia a el cuerpo de nuestro jugador
    public Transform playerBody;

    // 5. Variable de rotación en x
    private float xRotation = 0f;

    private void Start()
    {
        // 8.Hacer que el cursor se quee en su lugar
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 1.Obtener información de nuestros ejes
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        // 5. Tomar la rotación de mouseY;
        xRotation -= mouseY;

        // 6. Clamp rotación para que no pase de ciertos valotes
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 7. Aplicar la rotación
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 4.Hacer que rote el cuerpo del jugador con el movimiento de nuestro mouse
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
