using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipPath : MonoBehaviour
{
    [SerializeField] NavMeshAgent Barco;
    [SerializeField] GameObject ShipTarget;
    private Vector3 pPosition;

    private void Start()
    {
        Barco = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    [SerializeField] Transform player;
    [SerializeField] Transform ship;
    
    bool hasPlayer = false;
    


    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist < 3.5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        if (hasPlayer && Input.GetKeyDown(KeyCode.Q))
        {

            ShipTarget = GameObject.FindGameObjectWithTag("ShipTarget");
            pPosition = ShipTarget.transform.position;
            Barco.SetDestination(pPosition);

        }

        
    }
}
