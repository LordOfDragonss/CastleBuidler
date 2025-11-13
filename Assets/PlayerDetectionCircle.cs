using UnityEngine;

public class PlayerDetectionCircle : MonoBehaviour
{
    public bool playerDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDetected = false;
        }
    }
}
