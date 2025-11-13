using System;
using UnityEngine;

public class BasicGroundedCreatureAi : MonoBehaviour
{
    [SerializeField] internal Animator CreatureAnimator;
    [SerializeField] internal Rigidbody2D Rb;

    public LayerMask groundLayers;
    public Transform groundCheckPosition;
    public Transform wallCheckPosition;
    internal Vector3 forwardMovement;
    public float movementSpeed;
    bool hasTurned;
    public bool canFlipOnWall = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        forwardMovement = new Vector3(1,0,0);
    }

    // Update is called once per frame
    internal void Update()
    {
        Rb.linearVelocity = forwardMovement * movementSpeed;
        Debug.Log($"[{gameObject.name}]'s linear velocity is {Rb.linearVelocity}");
        if (!IsGrounded() || hitWall() && canFlipOnWall)
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

    internal bool IsGrounded()
    {
        RaycastHit2D groundCast = Physics2D.Raycast(groundCheckPosition.position, -transform.up, .1f, groundLayers);
        return groundCast.collider;
    }

    internal bool hitWall()
    {
        RaycastHit2D wallCast = Physics2D.Raycast(wallCheckPosition.position, transform.forward, .1f, groundLayers);
        return wallCast.collider;
    }

    internal bool IsMoving()
    {
        return Rb.linearVelocity.sqrMagnitude > 0.01f;
    }
}
