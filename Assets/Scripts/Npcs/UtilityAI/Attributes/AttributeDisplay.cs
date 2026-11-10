using TMPro;
using UnityEngine;

public class AttributeDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PhysiqueValue;
    [SerializeField] private TextMeshProUGUI AgilityValue;
    [SerializeField] private TextMeshProUGUI FinesseValue;
    [SerializeField] private TextMeshProUGUI NatureValue;
    [SerializeField] private TextMeshProUGUI IntelligenceValue;
    [SerializeField] private TextMeshProUGUI IngenuityValue;
    [SerializeField] private TextMeshProUGUI PerceptionValue;
    [SerializeField] private TextMeshProUGUI RecallValue;
    [SerializeField] private TextMeshProUGUI CharismaValue;
    [SerializeField] private TextMeshProUGUI EmpathyValue;
    public NPCAttributes attributes;
    public Transform followTransform;
    private Transform mainCameraTransform;

    private void OnEnable()
    {
        if (attributes != null)
            attributes.OnAttributeValueChanged += UpdateAttributes;
    }

    private void OnDisable()
    {
        if (attributes != null)
            attributes.OnAttributeValueChanged -= UpdateAttributes;
    }
    // Start is called before the first frame update
    void Start()
    {
        mainCameraTransform = Camera.main.transform;
        UpdateAttributes();
    }



    void LateUpdate()
    {
        transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
        transform.position = new Vector3(followTransform.position.x, transform.position.y, followTransform.position.z);
    }


    public void UpdateAttributes()
    {
        PhysiqueValue.text = Mathf.RoundToInt(attributes.Physique).ToString();
        AgilityValue.text = Mathf.RoundToInt(attributes.Agility).ToString();

        FinesseValue.text = Mathf.RoundToInt(attributes.Finesse).ToString();
        NatureValue.text = Mathf.RoundToInt(attributes.Nature).ToString();

        IntelligenceValue.text = Mathf.RoundToInt(attributes.Intelligence).ToString();
        IngenuityValue.text = Mathf.RoundToInt(attributes.Ingenuity).ToString();

        PerceptionValue.text = Mathf.RoundToInt(attributes.Perception).ToString();
        RecallValue.text = Mathf.RoundToInt(attributes.Recall).ToString();

        CharismaValue.text = Mathf.RoundToInt(attributes.Charisma).ToString();
        EmpathyValue.text = Mathf.RoundToInt(attributes.Empathy).ToString();
    }


}
