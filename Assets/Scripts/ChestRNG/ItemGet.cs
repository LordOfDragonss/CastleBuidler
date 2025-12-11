using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemGet : MonoBehaviour
{
    public Animator animator;
    public Image image;
    public TextMeshProUGUI NameText;

    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void GetItem()
    {
        gameObject.SetActive(true);
        animator.SetTrigger("ItemGet");
    }

    public void setNameColorOnRarity(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.Common:
                NameText.color = Color.green;
                break;
            case Rarity.Rare:
                NameText.color = Color.magenta;
                break;
            case Rarity.Legendary:
                NameText.color = Color.yellow;
                break;
        }
    }
}
