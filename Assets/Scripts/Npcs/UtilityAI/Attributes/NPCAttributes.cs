
using UnityEngine;

public class NPCAttributes : MonoBehaviour
{
    [Header("Attributes")]
    public float Physique;
    public float Finesse;
    public float Agility;
    public float Nature;
    public float Perception;
    public float Intelligence;
    public float Ingenuity;
    public float Recall;
    public float Charisma;
    public float Empathy;



    [Header("Settings")]
    public bool StartRandomized = true;
    public float MinAttributeRange = 0f;
    public float MaxAttributeRange = 10f;
    //[Header("Events")]
    public delegate void AttributeValueChangedHandler();
    public event AttributeValueChangedHandler OnAttributeValueChanged;

    private void Start()
    {
        if (StartRandomized)
            GenerateRandomStarterAttributes();
    }

    private float GenerateRandomAttributeNumber()
    {
        return Random.Range(MinAttributeRange, MaxAttributeRange);
    }

    public void GenerateRandomStarterAttributes()
    {
        foreach (AttributeType attribute in System.Enum.GetValues(typeof(AttributeType)))
        {
            SetAttribute(attribute, GenerateRandomAttributeNumber());
        }
    }

    public void SetAttribute(AttributeType attribute, float value)
    {
        switch (attribute)
        {
            case AttributeType.Physique: Physique = Mathf.Clamp(value, MinAttributeRange, MaxAttributeRange); break;
            case AttributeType.Finesse: Finesse = Mathf.Clamp(value, MinAttributeRange, MaxAttributeRange); break;
            case AttributeType.Agility: Agility = Mathf.Clamp(value, MinAttributeRange, MaxAttributeRange); break;
            case AttributeType.Nature: Nature = Mathf.Clamp(value, MinAttributeRange, MaxAttributeRange); break;
            case AttributeType.Perception: Perception = Mathf.Clamp(value, MinAttributeRange, MaxAttributeRange); break;
            case AttributeType.Intelligence: Intelligence = Mathf.Clamp(value, MinAttributeRange, MaxAttributeRange); break;
            case AttributeType.Ingenuity: Ingenuity = Mathf.Clamp(value, MinAttributeRange, MaxAttributeRange); break;
            case AttributeType.Recall: Recall = Mathf.Clamp(value, MinAttributeRange, MaxAttributeRange); break;
            case AttributeType.Charisma: Charisma = Mathf.Clamp(value, MinAttributeRange, MaxAttributeRange); break;
            case AttributeType.Empathy: Empathy = Mathf.Clamp(value, MinAttributeRange, MaxAttributeRange); break;
        }
        OnAttributeValueChanged?.Invoke();
    }


    public void ModifyAttribute(AttributeType attribute, float amount)
    {
        switch (attribute)
        {
            case AttributeType.Physique:
                Physique = Mathf.Clamp(Physique + amount, MinAttributeRange, MaxAttributeRange);
                break;

            case AttributeType.Finesse:
                Finesse = Mathf.Clamp(Finesse + amount, MinAttributeRange, MaxAttributeRange);
                break;

            case AttributeType.Agility:
                Agility = Mathf.Clamp(Agility + amount, MinAttributeRange, MaxAttributeRange);
                break;

            case AttributeType.Nature:
                Nature = Mathf.Clamp(Nature + amount, MinAttributeRange, MaxAttributeRange);
                break;

            case AttributeType.Perception:
                Perception = Mathf.Clamp(Perception + amount, MinAttributeRange, MaxAttributeRange);
                break;

            case AttributeType.Intelligence:
                Intelligence = Mathf.Clamp(Intelligence + amount, MinAttributeRange, MaxAttributeRange);
                break;

            case AttributeType.Ingenuity:
                Ingenuity = Mathf.Clamp(Ingenuity + amount, MinAttributeRange, MaxAttributeRange);
                break;

            case AttributeType.Recall:
                Recall = Mathf.Clamp(Recall + amount, MinAttributeRange, MaxAttributeRange);
                break;

            case AttributeType.Charisma:
                Charisma = Mathf.Clamp(Charisma + amount, MinAttributeRange, MaxAttributeRange);
                break;

            case AttributeType.Empathy:
                Empathy = Mathf.Clamp(Empathy + amount, MinAttributeRange, MaxAttributeRange);
                break;
        }
        OnAttributeValueChanged?.Invoke();
    }

}
