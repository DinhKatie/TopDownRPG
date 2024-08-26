using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;

    //the "square" of the camera: if the player moves out of bounds, move the camera
    public float boundX = 0.3f;
    public float boundY = 0.15f;

    private void Start()
    {
        lookAt = GameObject.Find("Player").transform;
    }

    //Called after Update() and FixedUpdate()
    //Move camera AFTER player has done their movement
    private void LateUpdate()
    {
        //How much the camera needs to move
        Vector3 delta = Vector3.zero;

        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            //If player has moved to the right
            if (transform.position.x < lookAt.position.x)
                delta.x = deltaX - boundX; //Move camera right to keep player within boundary
            else
                delta.x = deltaX + boundX;
        }

        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
                delta.y = deltaY - boundY;
            else
                delta.y = deltaY + boundY;
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
