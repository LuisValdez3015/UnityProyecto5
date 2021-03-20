using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject player;
    private Vector3 pPosition;
    Mecanica mecanica;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mecanica = GetComponent<Mecanica>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (mecanica.CuboAzul == true)
        {
            agent.speed = agent.speed/2;
        }
        
    }
    void Move()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pPosition = player.transform.position;
        agent.SetDestination(pPosition);
    }
}
