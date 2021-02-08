using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        Movement movimiento = FindObjectOfType<Movement>();
        movimiento.SetLastCheckPoint(this);
    }


}
