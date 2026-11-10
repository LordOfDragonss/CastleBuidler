
using UnityEngine;

public class AttributeTester : MonoBehaviour
{
    [SerializeField] private NPCAttributes attributes;
    public float amount;
    public AttributeType attributeType;

    [ContextMenu("Increase Attribute")]
    public void IncreaseAttribute()
    {
        attributes.ModifyAttribute(attributeType, amount);
    }
    [ContextMenu("Decrease Attribute")]
    public void DecreaseAttribute()
    {
        attributes.ModifyAttribute(attributeType, -amount);
    }
}
