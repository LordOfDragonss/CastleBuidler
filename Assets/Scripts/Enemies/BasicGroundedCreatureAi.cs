using System;
using UnityEngine;

public class BasicGroundedCreatureAi : MonoBehaviour
{
    [SerializeField] Animator CreatureAnimator;
    [SerializeField] Rigidbody2D Rb;

    public LayerMask groundLayers;
    public Transform groundCheckPosition;
    public Transform wallCheckPosition;
    private Vector3 forwardMovement;
    public float movementSpeed;
    bool hasTurned;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        forwardMovement = new Vector3(1,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Rb.linearVelocity = forwardMovement * movementSpeed;
        if (!IsGrounded() || hitWall())
        {
            if (!hasTurned)
            {
                transform.rotation *= Quaternion.Euler(0, 180, 0);
                forwardMovement = -forwardMovement;
                hasTurned = true;
            }
        }
        else
        {
            hasTurned = false;
        }



        CreatureAnimator.SetBool("Walking", IsMoving());
    }

    bool IsGrounded()
    {
        RaycastHit2D groundCast = Physics2D.Raycast(groundCheckPosition.position, -transform.up, .1f, groundLayers);
        return groundCast.collider;
    }

    bool hitWall()
    {
        RaycastHit2D wallCast = Physics2D.Raycast(wallCheckPosition.position, transform.forward, .1f, groundLayers);
        return wallCast.collider;
    }

    bool IsMoving()
    {
        return Rb.linearVelocity.sqrMagnitude > 0.01f;
    }
}
