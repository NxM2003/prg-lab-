using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmycontrol : MonoBehaviour
{
    internal virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Player in range !!Attack!!");
        }
        else
        {
            print("Player has been lost.");
        }
    }

   
}


