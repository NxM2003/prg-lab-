using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public CharacterController controller;
    [SerializeField] public float speed;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public Rigidbody rb;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletParent;
    [SerializeField] private float bulletVelocity = 40f;

    Vector3 velocity;
    bool isGrounded;
     public bool disableMovement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

       if(! disableMovement)
        {
            Walk();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Walk()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        //controller.Move(move * speed * Time.deltaTime);
        transform.position += move * speed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        //velocity.y = gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            bullet.transform.parent =   null;
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletVelocity;
            Destroy(bullet.gameObject, 5f);
        }
    }


    void Jump()
    {
        rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);

    }

}

   
