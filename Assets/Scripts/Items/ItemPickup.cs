using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
    void PickUp()
    {
        Debug.Log("Pick Up: " + item.name);
        bool isPickedUp = Inventory.instance.AddItem(item);

        if (isPickedUp)
            Destroy(gameObject);
    }
}
