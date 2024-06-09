using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player

    float moveHorizontal, moveVertical;

    private Rigidbody rb;

    public bool freeze;
    public GameObject ball;

    void Start()
    {
        if (gameObject.name == "RedPlayer")
        {
            rb = GameObject.Find("RedPlayer").GetComponent<Rigidbody>();
        }
        else if (gameObject.name == "BluePlayer")
        {
            rb = GameObject.Find("BluePlayer").GetComponent<Rigidbody>();
        }

    }

    void Update()
    {

        // moveHorizontal = Input.GetAxisRaw("Horizontal1");
        moveVertical = Input.GetAxisRaw("Vertical1");

        // Calculate movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        if (ball == null)
        {
            if (movement.magnitude >= 0.1f)
            {
                MovePlayer(movement);
            }
        }



    }

    void MovePlayer(Vector3 direction)
    {
        // Calculate target position
        Vector3 targetPosition = rb.position + direction * moveSpeed * Time.deltaTime;

        // Move the player
        rb.MovePosition(targetPosition);
    }
}
