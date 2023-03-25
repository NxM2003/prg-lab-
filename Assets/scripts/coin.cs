using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    Collectibles coins;

    private void Awake()
    {
        coins = new Collectibles("coin", 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            coins.UpdateScore();
        }
    }
}
