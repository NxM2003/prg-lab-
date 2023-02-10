using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmycontrol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Player in range !!Attack!!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Player has been lost.");
        }
    }
}


