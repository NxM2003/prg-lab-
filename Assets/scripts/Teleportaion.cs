using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportaion : MonoBehaviour
{
    playermovement _playercontroller;
    [SerializeField] GameObject teleportePosition;
    Coroutine _coroutine;
    // Start is called before the first frame update
    void Start()
    {
        _playercontroller = GetComponent<playermovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("teleporting to way point");
            _coroutine = StartCoroutine(TelepoterDealy());
           
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StopCoroutine(_coroutine);
        } 

    }   
     
    IEnumerator TelepoterDealy()
    {
        _playercontroller.disableMovement = true;
        yield return new WaitForSeconds(1.5f);
        gameObject.transform.position = teleportePosition.transform.position;
        yield return null;
        _playercontroller.disableMovement = false;
    }
}
