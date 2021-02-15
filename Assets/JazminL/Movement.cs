using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpforce;
    public bool isGrounded;

    Checkpoint checkPoint;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0f, -1f, 0f) * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0f, 1f, 0f) * rotationSpeed * Time.deltaTime);
        }



        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded))
        {
            Rigidbody rigibody = GetComponent<Rigidbody>();
            rigibody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

    }

    public void SetLastCheckPoint(Checkpoint checkPoint)
    {
        this.checkPoint = checkPoint;
    }
}
