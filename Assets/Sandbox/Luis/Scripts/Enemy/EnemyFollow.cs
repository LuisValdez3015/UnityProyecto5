using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 4f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(position);
        transform.LookAt(target);
    }
}
