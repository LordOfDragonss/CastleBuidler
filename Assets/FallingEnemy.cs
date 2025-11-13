using UnityEngine;

public class FallingEnemy : BasicGroundedCreatureAi
{
    [SerializeField]
    PlayerDetectionCircle PlayerVision;
    float randomPeekTimer;
    bool flipped = false;
    [SerializeField]
    Transform sprite;

    [SerializeField]
    Transform droppedgroundDetector;
    [SerializeField]
    Transform groundDetector;

    bool dropping;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (randomPeekTimer > 0 && !dropping)
        {
            randomPeekTimer -= 0.1f * Time.deltaTime;
        }

        if (randomPeekTimer <= 0 && !dropping)
        {
            CreatureAnimator.SetTrigger("Peek");
            randomPeekTimer = Random.Range(1, 5);
        }

        if (PlayerVision.playerDetected && !dropping && !flipped)
        {
            CreatureAnimator.SetTrigger("Drop");
            dropping = true;
        }
        if (flipped)
        {
            base.Update();
        }
        if(flipped && hitWall())
        {
            transform.rotation *= Quaternion.Euler(0, 0, 90);
        }
    }

    private void FixedUpdate()
    {
        if (dropping)
        {
            groundCheckPosition = droppedgroundDetector;
            if (IsGrounded())
            {
                dropping = false;
                flipEnemy();
                //Rb.gravityScale = 0;
                movementSpeed = 1;
                forwardMovement = new Vector3(1, 0, 0);
                canFlipOnWall = true;
                groundCheckPosition = groundDetector;
            }
            else
            {
                Rb.gravityScale = 1;
            }
        }
    }

    void flipEnemy()
    {
        if (!flipped)
        {
            Vector3 scale = transform.localScale;
            scale.y *= -1;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 1, transform.localPosition.z);
            transform.localScale = scale;
            flipped = true;
        }
    }
}
