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

    [Header("Jump")]
    public float jumpHeight;

    [Header("Animation")]
    public string moveBool = "Run";
    public Animator animator;

    #endregion


    void Update()
    {
        Jump();
        Movement();

    }
    private void OnValidate()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    private void Movement()
    {
        Running();

        if (Input.GetKey(KeyCode.D))
        {
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
            myRigidBody.transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool(moveBool, true);

        }

        else if (Input.GetKey(KeyCode.A))
        {
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
            myRigidBody.transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool(moveBool, true);

        }
        else 
            animator.SetBool(moveBool, false);


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
            animator.speed = 2;
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
