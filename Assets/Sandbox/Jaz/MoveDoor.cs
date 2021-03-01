using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    public GameObject door;
    bool isDooropen;
    public float speed;

    public void OpenDoor()
    {
        door.transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isDooropen)
        {
            OpenDoor();
            isDooropen = true;
            this.gameObject.SetActive(false);
        }
    }

}
