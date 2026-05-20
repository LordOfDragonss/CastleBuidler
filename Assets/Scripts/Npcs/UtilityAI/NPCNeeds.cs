using UnityEngine;

public class NPCNeeds : MonoBehaviour
{
    #region NeedSetters
    private int _energy;
    public int energy
    {
        get { return _energy; }
        set
        {
            _energy = Mathf.Clamp(value, 0, 100);
            OnStatValueChanged?.Invoke();
        }
    }
    private int _hunger;
    public int hunger
    {
        get { return _hunger; }
        set
        {
            _hunger = Mathf.Clamp(value, 0, 100);
            OnStatValueChanged?.Invoke();
        }
    }
    private int _money;
    public int money
    {
        get { return _money; }
        set
        {
            _money = Mathf.Clamp(value, 0, 100);
            OnStatValueChanged?.Invoke();
        }
    }
    #endregion

    [SerializeField] private float timeToDecreaseHunger = 5f;
    [SerializeField] private float timeToDecreaseEnergy = 5f;
    private float timeLeftEnergy;
    private float timeLeftHunger;
    [SerializeField] private NeedsDisplay needsDisplay;

    public delegate void StatValueChangedHandler();
    public event StatValueChangedHandler OnStatValueChanged;

    private void Start()
    {
        hunger = 0;
        energy = 100;
        money = 50;
    }

    private void OnEnable()
    {
        OnStatValueChanged += UpdateText;
    }

    private void OnDisable()
    {
        OnStatValueChanged -= UpdateText;
    }

    public void UpdateHunger()
    {
        if(timeLeftHunger > 0)
        {
            timeLeftHunger -= Time.deltaTime;
            return;
        }
        timeLeftHunger = timeToDecreaseHunger;
        hunger += 1;
    }

    public void UpdateEnergy()
    {
        if (timeLeftEnergy > 0)
        {
            timeLeftEnergy -= Time.deltaTime;
            return;
        }
        timeLeftEnergy = timeToDecreaseEnergy;
        energy -= 1;
    }

    public void UpdateText()
    {
        needsDisplay.UpdateNeeds(energy,hunger,money);
    }
}
