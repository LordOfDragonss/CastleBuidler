using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public float Movementspeed;
    public float JumpForce;
    Rigidbody2D rb;
    Vector3 moveinput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void Update()
    {
        rb.linearVelocity = (new Vector2( moveinput.x * Movementspeed,rb.linearVelocity.y));
    }

    public void OnMove(InputValue value)
    {
        moveinput = value.Get<Vector2>();

    }

    public void OnJump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
    }
}
