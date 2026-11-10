using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NeedsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hungerValue;
    [SerializeField] private TextMeshProUGUI energyValue;
    [SerializeField] private TextMeshProUGUI moneyValue;

    [SerializeField] private Slider HungerSlider;
    [SerializeField] private Slider EnergySlider;
    [SerializeField] private Slider MoneySlider;
    public Transform followTransform;
    private Transform mainCameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        mainCameraTransform = Camera.main.transform;

    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
        transform.position = new Vector3(followTransform.position.x,transform.position.y,followTransform.position.z);
    }

    public void UpdateNeeds(int energy,int hunger,int money)
    {
        hungerValue.text = hunger.ToString();
        energyValue.text = energy.ToString();
        moneyValue.text = money.ToString();

        HungerSlider.value = hunger;
        EnergySlider.value = energy;
        MoneySlider.value = money;
    }
}
