using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class SecondDimensionPlayerController : MonoBehaviour
{
    public float Movementspeed;
    public float JumpForce;
    public float groundCheckDistance = 0.5f;
    Rigidbody2D rb;
    Vector3 moveinput;
    public LayerMask floorLayers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.linearVelocity = (new Vector2(moveinput.x * Movementspeed, rb.linearVelocity.y));
    }

    public void OnMove(InputValue value)
    {
        moveinput = value.Get<Vector2>();
    }

    public void OnJump()
    {
        if (isOnGround())
        {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        }
    }

    public bool isOnGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, floorLayers) ||
               Physics2D.Raycast(transform.position + new Vector3(0.5f, 0, 0), Vector2.down, groundCheckDistance, floorLayers) ||
               Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0, 0), Vector2.down, groundCheckDistance, floorLayers);
    }
}
