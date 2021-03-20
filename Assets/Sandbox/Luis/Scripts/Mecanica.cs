using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanica : MonoBehaviour
{
    public GameObject CuboAzul;

    private void OnTriggerEnter(Collider other)
    {
        CuboAzul.SetActive(true);
    }
}
