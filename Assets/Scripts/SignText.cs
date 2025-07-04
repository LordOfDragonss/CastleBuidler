using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class SignText : MonoBehaviour
{

    [SerializeField]

    private void Start()
    {
        SetText(text);
    }

    private string text;

    [SerializeField] private TextMeshProUGUI SignBox;
    
    public void SetText(string text)
    {
        SignBox.text = text;
        this.text = text;
    }
}
