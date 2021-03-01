using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    public GameObject CuboAzul;

    private void OnTriggerEnter(Collider other)
    {
        CuboAzul.SetActive(true);
    }


}
