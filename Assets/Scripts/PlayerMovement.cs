using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float targetAngle = 0;
    public float turningSpeed = 15f;

    void Update()
    {
        RotationUpdate();
    }

    void RotationUpdate()
    {
        if (transform.rotation.y > targetAngle)
        {
            turningSpeed = 0;
        }

        transform.Rotate(0f, turningSpeed * Time.deltaTime, 0f);
    }

    public void DashRight()
    {
        targetAngle -= 30f;
        turningSpeed = -100;
    }

    public void DashLeft()
    {
        targetAngle += 30f;
        turningSpeed = 100;
    }

    public void Jump()
    {

    }

    public void Duck()
    {

    }
}
