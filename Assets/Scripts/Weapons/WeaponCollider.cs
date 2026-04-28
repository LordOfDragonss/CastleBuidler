using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public float damage;
    public LayerMask hittableLayers;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsInLayerMask(other.gameObject, hittableLayers))
        {
            var health = other.gameObject.GetComponent<HealthSystem>();
            if (health != null)
            {
                health.ReduceHealth(damage);
            }
        }
    }
    bool IsInLayerMask(GameObject obj, LayerMask mask)
    {
        return (mask.value & (1 << obj.layer)) != 0;
    }
}
