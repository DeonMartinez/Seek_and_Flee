using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekOrFlee : MonoBehaviour
{
    public GameObject player;
    public bool courage = true;
    public float speed = 1f;


    public float newOrientation(float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
        {
            return Mathf.Atan2(velocity.x, velocity.z);
        }

        else
        {
            return current;
        }
    }

    public SteeringOutput getSteering()
    {
        SteeringOutput heading = new SteeringOutput();

        heading.vel = player.transform.position - this.transform.position;

        heading.vel.Normalize();
        if (courage == true)
            heading.vel *= speed;
        if (courage == false)
            heading.vel *= -speed;

        float orientation = newOrientation(transform.eulerAngles.y, heading.vel);
        this.transform.eulerAngles = new Vector3(0, orientation * (180 / Mathf.PI), 0);

        return heading;
    }


    // Update is called once per frame
    void Update()
    {
        SteeringOutput steeringOutput = getSteering();
        transform.position += steeringOutput.vel * Time.deltaTime;
    }
}
