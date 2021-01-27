using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public int frwSpeed = 2000;
    public int lateralSpeed = 200;

    void FixedUpdate()
    {
        rb.AddForce(0, 0, frwSpeed * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(lateralSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-lateralSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
