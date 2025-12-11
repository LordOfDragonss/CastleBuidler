using UnityEngine;

public class ChestInteract : MonoBehaviour
{
    public ChestDrop lootTable;
    public Animator ChestAnimator;
    public ItemGet ItemGet;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ChestAnimator.SetTrigger("Open");
            lootTable.Open();
            ItemGet.image.sprite = lootTable.droppedItem.sprite;
            ItemGet.setNameColorOnRarity(lootTable.droppedItem.Rarity);
            ItemGet.NameText.text = "Get: " + lootTable.droppedItem.Name;
            ItemGet.GetItem();
        }
    }
}
