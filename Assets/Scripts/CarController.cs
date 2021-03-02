using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 15f, turnSpeed = 100.0f;
    private float moveDirection;
    private bool getInCar, closePlayer;
    public GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && closePlayer)
        {
            getInCar = !getInCar;
        }
        if(getInCar && closePlayer)
        {
            moveDirection = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            if (Input.GetAxis("Vertical")== 0)
                rb.isKinematic = true;
            else
                rb.isKinematic = false;

            rb.MovePosition(transform.position + transform.forward * moveDirection);
            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
           
            player.SetActive(false);
            player.transform.position = new Vector3(transform.position.x-2, transform.position.y, transform.position.z);
        }
        else
        {
            rb.isKinematic = true;
            player.SetActive(true);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            closePlayer = true;
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            closePlayer = false;

    }
}
