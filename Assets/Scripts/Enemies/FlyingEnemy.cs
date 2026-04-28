using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public HealthSystem healthSystem;

    private void Update()
    {
        if(healthSystem.currenthealth <= 0)
        {
            healthSystem.currenthealth = 0;
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
