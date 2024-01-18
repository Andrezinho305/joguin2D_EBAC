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

    [Header("Jump Collision Check")]
    public float distToGround = 0f;
    public float spaceToGround = .1f; 
    public Collider2D collider2D;


    #endregion

    private void Awake()
    {
        if (collider2D != null)
        {
            distToGround = collider2D.bounds.extents.y;
        }
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, distToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + spaceToGround);
    }


    void Update()
    {
        IsGrounded();
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
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            myRigidBody.velocity = Vector2.up * soPlayer.jumpHeight;
            PlayJumpVFX();
        }
    }

    private void PlayJumpVFX()
    {
        VFXManager.Instance.PlayVFXbyType(VFXManager.VFXType.JUMP, transform.position);
    }
}
