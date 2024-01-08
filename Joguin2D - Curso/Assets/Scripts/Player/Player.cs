using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    #region Variables

    public Rigidbody2D myRigidBody;

    public SOPlayer soPlayer;

    public Animator animator;

    private float _currentSpeed;


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
            animator.SetBool(soPlayer.moveBool, true);

        }

        else if (Input.GetKey(KeyCode.A))
        {
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
            myRigidBody.transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool(soPlayer.moveBool, true);

        }
        else
            animator.SetBool(soPlayer.moveBool, false);


        if (myRigidBody.velocity.x > 0)
        {
            myRigidBody.velocity -= soPlayer.friction;
        }
        else if (myRigidBody.velocity.x < 0)
        {
            myRigidBody.velocity += soPlayer.friction;
        }


    }

    private void Running()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = soPlayer.speedRun;
            animator.speed = 2;
        }
        else
        {
            _currentSpeed = soPlayer.speed;
        }


    }


    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = Vector2.up * soPlayer.jumpHeight;
        }
    }

}
