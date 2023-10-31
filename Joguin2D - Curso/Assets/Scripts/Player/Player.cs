using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables

    public Rigidbody2D myRigidBody;

    [Header("Movement")]
    public float speed;
    public Vector2 friction = new Vector2(.1f, 0);


    [Header("Running")]
    public float speedRun;
    private float _currentSpeed;
    private bool _isRunning = false;


    [Header("Jump")]
    public float jumpHeight;

    #endregion


    void Update()
    {
        Jump();
        Movement();

    }

    private void Movement()
    {
        Running();

        if (Input.GetKey(KeyCode.D))
        {
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
        }


        if (myRigidBody.velocity.x > 0)
        {
            myRigidBody.velocity -= friction;
        }
        else if (myRigidBody.velocity.x < 0)
        {
            myRigidBody.velocity += friction;
        }


    }

    private void Running()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }


    }


    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = Vector2.up * jumpHeight;
        }
    }

}
